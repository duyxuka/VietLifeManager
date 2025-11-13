using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.SanPhamsList.SanPhams;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.SanPhamsList.SanPhams
{
    public interface ISanPhamsAppService : ICrudAppService
        <SanPhamDto, Guid, PagedResultRequestDto, CreateUpdateSanPhamDto, CreateUpdateSanPhamDto>
    {
        Task<PagedResultDto<SanPhamInListDto>> GetListFilterAsync(SanPhamListFilterDto input);
        Task<List<SanPhamInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);

        Task<string> GetThumbnailImageAsync(string fileName);
        Task<string> GetSuggestNewCodeAsync();

    }
}
