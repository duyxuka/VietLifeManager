using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.SanPhamsList.DonViTinhs
{
    public interface IDonViTinhsAppService : ICrudAppService<
        DonViTinhDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateDonViTinhDto,
        CreateUpdateDonViTinhDto>
    {
        Task<PagedResultDto<DonViTinhInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<DonViTinhInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
