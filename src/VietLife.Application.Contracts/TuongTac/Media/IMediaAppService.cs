using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Content;

namespace VietLife.TuongTac.Media
{
    public interface IMediaAppService
    {
        Task<UploadResultDto> UploadAsync(IFormFile file);
        Task<IRemoteStreamContent> GetAsync(string fileName);
        Task DeleteAsync(string fileName);
    }
}
