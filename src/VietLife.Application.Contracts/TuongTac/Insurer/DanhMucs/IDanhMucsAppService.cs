using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.TuongTac.Insurer.DanhMucs
{
    public interface IDanhMucsAppService : ICrudAppService
        <DanhMucDto, Guid, PagedResultRequestDto, CreateUpdateDanhMucDto, CreateUpdateDanhMucDto>
    {
        Task<PagedResultDto<DanhMucInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<DanhMucInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
