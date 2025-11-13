using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.KhoHangs
{
    public interface IKhoHangsAppService : ICrudAppService<
        KhoHangDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateKhoHangDto,
        CreateUpdateKhoHangDto>
    {
        Task<PagedResultDto<KhoHangInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<KhoHangInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
