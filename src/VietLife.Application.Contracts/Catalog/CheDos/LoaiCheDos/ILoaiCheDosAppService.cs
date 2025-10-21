using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.CheDos.LoaiCheDos
{
    public interface ILoaiCheDosAppService : ICrudAppService
        <LoaiCheDoDto, Guid, PagedResultRequestDto, CreateUpdateLoaiCheDoDto, CreateUpdateLoaiCheDoDto>
    {
        Task<PagedResultDto<LoaiCheDoInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<LoaiCheDoInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
