using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.TuongTac.Insurer.BaiViets
{
    public interface IBaiVietsAppService : ICrudAppService
        <BaiVietDto, Guid, PagedResultRequestDto, CreateUpdateBaiVietDto, CreateUpdateBaiVietDto>
    {
        Task<PagedResultDto<BaiVietInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<PagedResultDto<BaiVietInListDto>> GetListBySanPhamAsync(Guid sanPhamId, PagedResultRequestDto input);
        Task<PagedResultDto<BaiVietInListDto>> GetListByNhomAsync(Guid nhomId, PagedResultRequestDto input);
        Task<List<BaiVietInListDto>> GetListAllAsync();
        Task<List<BaiVietInListDto>> GetLatestAsync(int take = 6);
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
