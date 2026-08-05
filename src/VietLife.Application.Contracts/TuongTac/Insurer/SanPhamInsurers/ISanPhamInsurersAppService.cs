using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.SanPhamsList.SanPhams;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.TuongTac.Insurer.SanPhamInsurers
{
    public interface ISanPhamInsurersAppService : ICrudAppService
        <SanPhamInsurerDto, Guid, PagedResultRequestDto, CreateUpdateSanPhamInsurerDto, CreateUpdateSanPhamInsurerDto>
    {
        Task<PagedResultDto<SanPhamInsurerInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<SanPhamInsurerInListDto>> GetListAllAsync();
        Task<List<SanPhamInsurerInListDto>> GetListByNhomAsync(Guid nhomId);
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
        Task<string> GetThumbnailImageAsync(string fileName);
    }
}
