using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.ThanhPhos
{
    public interface IThanhPhosAppService : ICrudAppService<
        ThanhPhoDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateThanhPhoDto,
        CreateUpdateThanhPhoDto>
    {
        Task<PagedResultDto<ThanhPhoInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<ThanhPhoInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
