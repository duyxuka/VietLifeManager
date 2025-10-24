using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Catalog.LuongNhanViens
{
    public interface ILuongNhanViensAppService : ICrudAppService
        <LuongNhanVienDto, Guid, PagedResultRequestDto, CreateUpdateLuongNhanVienDto, CreateUpdateLuongNhanVienDto>
    {
        Task<PagedResultDto<LuongNhanVienInListDto>> GetListFilterAsync(LuongNhanVienListFilterDto input);
        Task<List<LuongNhanVienInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
