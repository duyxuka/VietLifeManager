using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.NhapXuats.LoaiNhapXuats
{
    public interface ILoaiNhapXuatsAppService : ICrudAppService<
        LoaiNhapXuatDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateLoaiNhapXuatDto,
        CreateUpdateLoaiNhapXuatDto>
    {
        Task<PagedResultDto<LoaiNhapXuatInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<LoaiNhapXuatInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
