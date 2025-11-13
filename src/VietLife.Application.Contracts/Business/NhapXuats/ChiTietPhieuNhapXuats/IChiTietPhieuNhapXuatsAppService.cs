using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.NhapXuats.ChiTietPhieuNhapXuats
{
    public interface IChiTietPhieuNhapXuatsAppService : ICrudAppService<
        ChiTietPhieuNhapXuatDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateChiTietPhieuNhapXuatDto,
        CreateUpdateChiTietPhieuNhapXuatDto>
    {
        Task<PagedResultDto<ChiTietPhieuNhapXuatInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<ChiTietPhieuNhapXuatInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
