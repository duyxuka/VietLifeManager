using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.ChamCongs
{
    public interface IChamCongsAppService : ICrudAppService
        <ChamCongDto, Guid, PagedResultRequestDto, CreateUpdateChamCongDto, CreateUpdateChamCongDto>
    {
        Task<PagedResultDto<ChamCongInListDto>> GetListFilterAsync(ChamCongListFilterDto input);
        Task<List<ChamCongInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);

        Task CheckInAsync();
        Task CheckOutAsync();
    }
}
