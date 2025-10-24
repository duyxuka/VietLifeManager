using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.KPIs.TienDoLamViecs
{
    public interface ITienDoLamViecsAppService : ICrudAppService
        <TienDoLamViecDto, Guid, PagedResultRequestDto, CreateUpdateTienDoLamViecDto, CreateUpdateTienDoLamViecDto>
    {
        Task<PagedResultDto<TienDoLamViecInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<TienDoLamViecInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
