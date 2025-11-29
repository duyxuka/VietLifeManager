using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.ThuChisList.LoaiThuChis
{
    public interface ILoaiThuChisAppService : ICrudAppService<
        LoaiThuChiDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateLoaiThuChiDto,
        CreateUpdateLoaiThuChiDto>
    {
        Task<PagedResultDto<LoaiThuChiInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<LoaiThuChiInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
