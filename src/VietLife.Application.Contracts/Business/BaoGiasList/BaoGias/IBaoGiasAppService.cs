using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.BaoGiasList.BaoGias
{
    public interface IBaoGiasAppService : ICrudAppService<
         BaoGiaDto,
         Guid,
         PagedResultRequestDto,
         CreateUpdateBaoGiaDto,
         CreateUpdateBaoGiaDto>
    {
        Task<PagedResultDto<BaoGiaInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<BaoGiaInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
