using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.TuongTac.Insurer.Nhoms
{
    public interface INhomsAppService : ICrudAppService
        <NhomDto, Guid, PagedResultRequestDto, CreateUpdateNhomDto, CreateUpdateNhomDto>
    {
        Task<PagedResultDto<NhomInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<NhomInListDto>> GetListAllAsync();
        Task<List<NhomInListDto>> GetListByDanhMucAsync(Guid danhMucId);
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
