using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.LichLamViecs
{
    public interface ILichLamViecsAppService : ICrudAppService
        <LichLamViecDto, Guid, PagedResultRequestDto, CreateUpdateLichLamViecDto, CreateUpdateLichLamViecDto>
    {
        Task<PagedResultDto<LichLamViecInListDto>> GetListFilterAsync(LichLamViecListFilterDto input);
        Task<List<LichLamViecInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
