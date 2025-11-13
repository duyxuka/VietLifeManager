using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.DonHangsList.LoaiDonHangs
{
    public interface ILoaiDonHangAppService : ICrudAppService<
        LoaiDonHangDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateLoaiDonHangDto,
        CreateUpdateLoaiDonHangDto>
    {
        Task<PagedResultDto<LoaiDonHangInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<LoaiDonHangInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
