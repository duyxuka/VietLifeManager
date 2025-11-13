using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.BaoGiasList.ChiTietBaoGias
{
    public interface IChiTietBaoGiasAppService : ICrudAppService<
        ChiTietBaoGiaDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateChiTietBaoGiaDto,
        CreateUpdateChiTietBaoGiaDto>
    {
        Task<PagedResultDto<ChiTietBaoGiaInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<ChiTietBaoGiaInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
