using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.ThuChisList.TaiKhoanKeToans
{
    public interface ITaiKhoanKeToansAppService : ICrudAppService<
        TaiKhoanKeToanDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateTaiKhoanKeToanDto,
        CreateUpdateTaiKhoanKeToanDto>
    {
        Task<PagedResultDto<TaiKhoanKeToanInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<TaiKhoanKeToanInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
