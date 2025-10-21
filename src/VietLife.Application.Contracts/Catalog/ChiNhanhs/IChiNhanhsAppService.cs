using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.ChiNhanhs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.ChiNhanhs
{
    public interface IChiNhanhsAppService : ICrudAppService
        <ChiNhanhDto, Guid, PagedResultRequestDto, CreateUpdateChiNhanhDto, CreateUpdateChiNhanhDto>
    {
        Task<PagedResultDto<ChiNhanhInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<ChiNhanhInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
