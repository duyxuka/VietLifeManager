using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;
using Volo.Abp;
using VietLife.TuongTac.Media;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VietLife.TuongTac.MediaContainers;

namespace VietLife.TuongTac
{
    [AllowAnonymous]
    public class MediaAppService : ApplicationService, IMediaAppService
    {
        private readonly IBlobContainer<MediaContainer> _mediaContainer;

        // ✅ Tách riêng danh sách ảnh và PDF để áp giới hạn kích thước khác nhau
        private static readonly string[] AllowedImageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        private static readonly string[] AllowedDocumentExtensions = { ".pdf" };

        private const long MaxImageSize = 5 * 1024 * 1024;   // 5MB
        private const long MaxDocumentSize = 10 * 1024 * 1024; // 10MB

        public MediaAppService(IBlobContainer<MediaContainer> mediaContainer)
        {
            _mediaContainer = mediaContainer;
        }

        // ================= UPLOAD =================
        public async Task<UploadResultDto> UploadAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new UserFriendlyException("File không hợp lệ");

            var extension = Path.GetExtension(file.FileName).ToLower();

            var isImage = Array.Exists(AllowedImageExtensions, x => x == extension);
            var isDocument = Array.Exists(AllowedDocumentExtensions, x => x == extension);

            if (!isImage && !isDocument)
                throw new UserFriendlyException("Chỉ cho phép upload ảnh (jpg, png, gif, webp) hoặc file PDF");

            // ⚠️ Kiểm tra thêm content-type thực tế để tránh giả mạo phần mở rộng
            // (VD: đổi tên virus.exe thành virus.pdf) — kiểm tra magic bytes cho PDF
            if (isDocument && !await IsValidPdfAsync(file))
                throw new UserFriendlyException("File không phải PDF hợp lệ");

            var maxSize = isImage ? MaxImageSize : MaxDocumentSize;
            if (file.Length > maxSize)
                throw new UserFriendlyException($"File quá lớn (tối đa {maxSize / 1024 / 1024}MB)");

            var fileName = Guid.NewGuid() + extension;
            using (var stream = file.OpenReadStream())
            {
                await _mediaContainer.SaveAsync(fileName, stream, overrideExisting: true);
            }

            return new UploadResultDto { Result = fileName };
        }

        [HttpGet]
        [Route("files/{fileName}")]
        public async Task<IActionResult> GetFileAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new UserFriendlyException("File không hợp lệ");

            try
            {
                var stream = await _mediaContainer.GetAsync(fileName);

                if (stream == null)
                    throw new UserFriendlyException("Không tìm thấy file");

                var contentType = GetContentType(fileName);
                return new FileStreamResult(stream, contentType)
                {
                    EnableRangeProcessing = true
                };
            }
            catch
            {
                throw new UserFriendlyException("Không tìm thấy file");
            }
        }

        // ================= GET - Legacy (giữ lại cho backward compatibility) =================
        public async Task<IRemoteStreamContent> GetAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new UserFriendlyException("File không hợp lệ");

            var stream = await _mediaContainer.GetAsync(fileName);

            if (stream == null)
                throw new UserFriendlyException("Không tìm thấy file");

            return new RemoteStreamContent(
                stream,
                fileName,
                GetContentType(fileName)
            );
        }

        // ================= DELETE =================
        public async Task DeleteAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return;

            await _mediaContainer.DeleteAsync(fileName);
        }

        private string GetContentType(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLower();

            return ext switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".webp" => "image/webp",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }

        /// <summary>
        /// Kiểm tra magic bytes của PDF (%PDF- ở đầu file) để đảm bảo file thực sự là PDF,
        /// tránh trường hợp người dùng đổi tên file bất kỳ thành .pdf để bypass validation.
        /// </summary>
        private async Task<bool> IsValidPdfAsync(IFormFile file)
        {
            var header = new byte[5];
            using (var stream = file.OpenReadStream())
            {
                var bytesRead = await stream.ReadAsync(header, 0, header.Length);
                if (bytesRead < 5) return false;
            }

            var signature = Encoding.ASCII.GetString(header);
            return signature == "%PDF-";
        }
    }
}