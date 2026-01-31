using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.PhongBans;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.TuongTac.TinTucs
{
    public interface ITinTucsAppService : ICrudAppService
        <TinTucDto, Guid, PagedResultRequestDto, CreateUpdateTinTucDto, CreateUpdateTinTucDto>
    {
        Task<PagedResultDto<TinTucInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<TinTucInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
        Task<string> GetThumbnailImageAsync(string fileName);
    }
}
