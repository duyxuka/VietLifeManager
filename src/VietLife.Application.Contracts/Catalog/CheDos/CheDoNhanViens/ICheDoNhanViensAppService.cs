using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.CheDos.CheDoNhanViens
{
    public interface ICheDoNhanViensAppService : ICrudAppService
        <CheDoNhanVienDto, Guid, PagedResultRequestDto, CreateUpdateCheDoNhanVienDto, CreateUpdateCheDoNhanVienDto>
    {
        Task<PagedResultDto<CheDoNhanVienInListDto>> GetListFilterAsync(CheDoNhanVienListFilterDto input);
        Task<List<CheDoNhanVienInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
