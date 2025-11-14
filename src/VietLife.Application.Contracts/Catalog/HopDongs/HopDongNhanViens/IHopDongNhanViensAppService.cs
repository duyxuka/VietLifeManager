using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.HopDongs.HopDongNhanViens
{
    public interface IHopDongNhanViensAppService : ICrudAppService<
        HopDongNhanVienDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateHopDongNhanVienDto,
        CreateUpdateHopDongNhanVienDto>
    {
        Task<PagedResultDto<HopDongNhanVienInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<HopDongNhanVienInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
