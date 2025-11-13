using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.NhapXuats.PhieuNhapXuats
{
    public interface IPhieuNhapXuatsAppService : ICrudAppService<
        PhieuNhapXuatDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdatePhieuNhapXuatDto,
        CreateUpdatePhieuNhapXuatDto>
    {
        Task<PagedResultDto<PhieuNhapXuatInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<PhieuNhapXuatInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
