using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.TuongTac.Insurer.DangKyTuVans
{
    public interface IDangKyTuVansAppService : ICrudAppService
        <DangKyTuVanDto, Guid, PagedResultRequestDto, CreateUpdateDangKyTuVanDto, CreateUpdateDangKyTuVanDto>
    {
        Task<PagedResultDto<DangKyTuVanInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<PagedResultDto<DangKyTuVanInListDto>> GetListBySanPhamAsync(Guid sanPhamId, PagedResultRequestDto input);
        Task<PagedResultDto<DangKyTuVanInListDto>> GetListByNhomAsync(Guid nhomId, PagedResultRequestDto input);
        Task<List<DangKyTuVanInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
