using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.KhachHangsList.LoaiKhachHangs
{
    public interface ILoaiKhachHangsAppService : ICrudAppService<
        LoaiKhachHangDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateLoaiKhachHangDto,
        CreateUpdateLoaiKhachHangDto>
    {
        Task<PagedResultDto<LoaiKhachHangInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<LoaiKhachHangInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
