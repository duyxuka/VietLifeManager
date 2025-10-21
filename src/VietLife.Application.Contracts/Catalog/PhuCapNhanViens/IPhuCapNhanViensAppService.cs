using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.PhuCapNhanViens
{
    public interface IPhuCapNhanViensAppService : ICrudAppService
        <PhuCapNhanVienDto, Guid, PagedResultRequestDto, CreateUpdatePhuCapNhanVienDto, CreateUpdatePhuCapNhanVienDto>
    {
        Task<PagedResultDto<PhuCapNhanVienInListDto>> GetListFilterAsync(PhuCapNhanVienFilterListDto input);
        Task<List<PhuCapNhanVienInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
