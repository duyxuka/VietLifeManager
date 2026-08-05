using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VietLife.Permissions;
using VietLife.TuongTac.Insurer;
using VietLife.TuongTac.Insurer.SanPhamInsurers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.TuongTac.Insurers
{
    public class SanPhamInsurersAppService : CrudAppService<
           SanPhamInsurer,
           SanPhamInsurerDto,
           Guid,
           PagedResultRequestDto,
           CreateUpdateSanPhamInsurerDto,
           CreateUpdateSanPhamInsurerDto>,
       ISanPhamInsurersAppService
    {
        private readonly IBlobContainer _fileContainer;

        public SanPhamInsurersAppService(
            IRepository<SanPhamInsurer, Guid> repository,
            IBlobContainer fileContainer)
            : base(repository)
        {
            _fileContainer = fileContainer;

            GetPolicyName = null;
            GetListPolicyName = null;
            CreatePolicyName = VietLifePermissions.SanPhamInsurer.Create;
            UpdatePolicyName = VietLifePermissions.SanPhamInsurer.Update;
            DeletePolicyName = VietLifePermissions.SanPhamInsurer.Delete;
        }

        // ================= CREATE =================
        [Authorize(VietLifePermissions.SanPhamInsurer.Create)]
        public override async Task<SanPhamInsurerDto> CreateAsync(CreateUpdateSanPhamInsurerDto input)
        {
            var sanPham = new SanPhamInsurer
            {
                NhomId = input.NhomId,
                Ten = input.Ten,
                Slug = input.Slug,
                QuyenLoi = input.QuyenLoi,
                BieuPhi = input.BieuPhi,
                TaiLieu = input.TaiLieu,
                KhuyenMai = input.KhuyenMai,
                DangKy = input.DangKy,
                ThuTu = input.ThuTu,
                HienThi = input.HienThi,
                SeoTitle = input.SeoTitle,
                SeoKeywords = input.SeoKeywords,
                SeoDescription = input.SeoDescription
            };

            var created = await Repository.InsertAsync(sanPham);
            return MapToGetOutputDto(created);
        }

        // ================= UPDATE =================
        [Authorize(VietLifePermissions.SanPhamInsurer.Update)]
        public override async Task<SanPhamInsurerDto> UpdateAsync(Guid id, CreateUpdateSanPhamInsurerDto input)
        {
            var sanPham = await Repository.GetAsync(id);

            sanPham.NhomId = input.NhomId;
            sanPham.Ten = input.Ten;
            sanPham.Slug = input.Slug;
            sanPham.QuyenLoi = input.QuyenLoi;
            sanPham.BieuPhi = input.BieuPhi;
            sanPham.TaiLieu = input.TaiLieu;
            sanPham.KhuyenMai = input.KhuyenMai;
            sanPham.DangKy = input.DangKy;
            sanPham.ThuTu = input.ThuTu;
            sanPham.HienThi = input.HienThi;
            sanPham.SeoTitle = input.SeoTitle;
            sanPham.SeoKeywords = input.SeoKeywords;
            sanPham.SeoDescription = input.SeoDescription;

            await Repository.UpdateAsync(sanPham);
            return MapToGetOutputDto(sanPham);
        }

        // ================= DELETE MULTIPLE =================
        [Authorize(VietLifePermissions.SanPhamInsurer.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        // ================= GET (public) =================
        [AllowAnonymous]
        public override async Task<SanPhamInsurerDto> GetAsync(Guid id)
        {
            var sanPham = await Repository.GetAsync(x => x.Id == id && x.HienThi);
            return ObjectMapper.Map<SanPhamInsurer, SanPhamInsurerDto>(sanPham);
        }

        // ================= GET ALL (admin) =================
        [Authorize(VietLifePermissions.SanPhamInsurer.View)]
        public async Task<List<SanPhamInsurerInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var list = await AsyncExecuter.ToListAsync(
                query.Where(x => x.HienThi)
                     .OrderBy(x => x.ThuTu)
            );
            return ObjectMapper.Map<List<SanPhamInsurer>, List<SanPhamInsurerInListDto>>(list);
        }

        // ================= FILTER + PAGING (public) =================
        [AllowAnonymous]
        public async Task<PagedResultDto<SanPhamInsurerInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.HienThi)
                .WhereIf(
                    !string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.Ten.Contains(input.Keyword)
                );

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query.OrderBy(x => x.ThuTu)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            return new PagedResultDto<SanPhamInsurerInListDto>(
            totalCount,
                ObjectMapper.Map<List<SanPhamInsurer>, List<SanPhamInsurerInListDto>>(items)
            );
        }

        // ================= LỌC THEO NHÓM (public) =================
        [AllowAnonymous]
        public async Task<List<SanPhamInsurerInListDto>> GetListByNhomAsync(Guid nhomId)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.HienThi && x.NhomId == nhomId)
                .OrderBy(x => x.ThuTu);

            var list = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<SanPhamInsurer>, List<SanPhamInsurerInListDto>>(list);
        }
        [AllowAnonymous]
        public async Task<SanPhamInsurerDto> GetBySlugAsync(string slug)
        {
            var query = await Repository.GetQueryableAsync();
            var sanPham = await AsyncExecuter.FirstOrDefaultAsync(
                query.Where(x => x.Slug == slug && x.HienThi)
            );

            if (sanPham == null)
                throw new Volo.Abp.UserFriendlyException($"Không tìm thấy sản phẩm với slug: '{slug}'");

            return ObjectMapper.Map<SanPhamInsurer, SanPhamInsurerDto>(sanPham);
        }
        // ================= IMAGE =================
        // SanPhamInsurer không có ảnh riêng nhưng giữ lại để
        // phòng khi cần upload file tài liệu / biểu phí sau này
        private async Task SaveThumbnailImageAsync(string fileName, string base64)
        {
            Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
            base64 = regex.Replace(base64, string.Empty);
            var bytes = Convert.FromBase64String(base64);
            await _fileContainer.SaveAsync(fileName, bytes, overrideExisting: true);
        }

        public async Task<string> GetThumbnailImageAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            var fileBytes = await _fileContainer.GetAllBytesOrNullAsync(fileName);
            if (fileBytes == null) return null;

            return Convert.ToBase64String(fileBytes);
        }
    }
}
