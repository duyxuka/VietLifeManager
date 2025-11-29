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
        Task<List<ChiTietPhieuNhapXuatDto>> GetListByPhieuIdAsync(Guid phieuId);
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
