using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.KPIs.KeHoachCongViecs
{
    public interface IKeHoachCongViecsAppService : ICrudAppService
        <KeHoachCongViecDto, Guid, PagedResultRequestDto, CreateUpdateKeHoachCongViecDto, CreateUpdateKeHoachCongViecDto>
    {
        Task<PagedResultDto<KeHoachCongViecInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<KeHoachCongViecInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
