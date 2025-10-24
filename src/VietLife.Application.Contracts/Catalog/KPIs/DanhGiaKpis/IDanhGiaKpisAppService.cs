using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.KPIs.DanhGiaKpis
{
    public interface IDanhGiaKpisAppService : ICrudAppService
        <DanhGiaKpiDto, Guid, PagedResultRequestDto, CreateUpdateDanhGiaKpiDto, CreateUpdateDanhGiaKpiDto>
    {
        Task<PagedResultDto<DanhGiaKpiInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<DanhGiaKpiInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
