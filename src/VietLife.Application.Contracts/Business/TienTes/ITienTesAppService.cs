using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.TienTes
{
    public interface ITienTesAppService : ICrudAppService<
        TienTeDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateTienTeDto,
        CreateUpdateTienTeDto>
    {
        Task<PagedResultDto<TienTeInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<TienTeInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
