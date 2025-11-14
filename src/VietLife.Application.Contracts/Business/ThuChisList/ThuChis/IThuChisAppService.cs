using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.ThuChisList.ThuChis
{
    public interface IThuChisAppService : ICrudAppService<
        ThuChiDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateThuChiDto,
        CreateUpdateThuChiDto>
    {
        Task<PagedResultDto<ThuChiInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<ThuChiInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
