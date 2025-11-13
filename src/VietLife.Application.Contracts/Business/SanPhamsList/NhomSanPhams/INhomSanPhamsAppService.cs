using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VietLife.Business.SanPhamsList.NhomSanPhams
{
    public interface INhomSanPhamsAppService : ICrudAppService<
        NhomSanPhamDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateNhomSanPhamDto,
        CreateUpdateNhomSanPhamDto>
    {
        Task<PagedResultDto<NhomSanPhamInListDto>> GetListFilterAsync(BaseListFilterDto input);
        Task<List<NhomSanPhamInListDto>> GetListAllAsync();
        Task DeleteMultipleAsync(IEnumerable<Guid> ids);
    }
}
