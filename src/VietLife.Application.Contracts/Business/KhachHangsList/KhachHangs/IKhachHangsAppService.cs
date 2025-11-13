using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.KhachHangsList.KhachHangs
{
    public interface IKhachHangsAppService : ICrudAppService<
        KhachHangDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateKhachHangDto,
        CreateUpdateKhachHangDto>
    {
        Task<PagedResultDto<KhachHangInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<KhachHangInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
