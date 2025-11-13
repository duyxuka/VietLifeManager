using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.DonHangsList.ChiTietDonHangs
{
    public interface IChiTietDonHangsAppService : ICrudAppService<
        ChiTietDonHangDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateChiTietDonHangDto,
        CreateUpdateChiTietDonHangDto>
    {
        Task<PagedResultDto<ChiTietDonHangInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<ChiTietDonHangInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
