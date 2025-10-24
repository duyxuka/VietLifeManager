using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.KPIs.MucTieuKpis
{
    public interface IMucTieuKpisAppService : ICrudAppService
        <MucTieuKpiDto, Guid, PagedResultRequestDto, CreateUpdateMucTieuKpiDto, CreateUpdateMucTieuKpiDto>
    {
        Task<PagedResultDto<MucTieuKpiInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<MucTieuKpiInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
