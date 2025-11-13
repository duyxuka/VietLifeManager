using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.HopDongs.LoaiHopDongs
{
    public interface ILoaiHopDongsAppService : ICrudAppService<
        LoaiHopDongDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateLoaiHopDongDto,
        CreateUpdateLoaiHopDongDto>
    {
        Task<PagedResultDto<LoaiHopDongInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<LoaiHopDongInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
