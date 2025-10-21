using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.ChucVus
{
    public interface IChucVusAppService : ICrudAppService
        <ChucVuDto, Guid, PagedResultRequestDto, CreateUpdateChucVuDto, CreateUpdateChucVuDto>
    {
        Task<PagedResultDto<ChucVuInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<ChucVuInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
