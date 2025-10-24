using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.KPIs.KpiNhanViens
{
    public interface IKpiNhanViensAppService : ICrudAppService
        <KpiNhanVienDto, Guid, PagedResultRequestDto, CreateUpdateKpiNhanVienDto, CreateUpdateKpiNhanVienDto>
    {
        Task<PagedResultDto<KpiNhanVienInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<KpiNhanVienInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
