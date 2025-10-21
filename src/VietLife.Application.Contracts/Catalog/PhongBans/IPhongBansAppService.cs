using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.PhongBans
{
    public interface IPhongBansAppService : ICrudAppService
        <PhongBanDto, Guid, PagedResultRequestDto, CreateUpdatePhongBanDto, CreateUpdatePhongBanDto>
    {
        Task<PagedResultDto<PhongBanInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<PhongBanInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
