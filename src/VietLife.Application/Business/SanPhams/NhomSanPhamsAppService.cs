using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.SanPhamsList.NhomSanPhams;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Business.SanPhams
{
    public class NhomSanPhamsAppService :
         CrudAppService<NhomSanPham, NhomSanPhamDto, Guid, PagedResultRequestDto, CreateUpdateNhomSanPhamDto, CreateUpdateNhomSanPhamDto>,
         INhomSanPhamsAppService
    {
        public NhomSanPhamsAppService(IRepository<NhomSanPham, Guid> repository) : base(repository)
        {
            GetPolicyName = VietLifePermissions.NhomSanPham.View;
            GetListPolicyName = VietLifePermissions.NhomSanPham.View;
            CreatePolicyName = VietLifePermissions.NhomSanPham.Create;
            UpdatePolicyName = VietLifePermissions.NhomSanPham.Update;
            DeletePolicyName = VietLifePermissions.NhomSanPham.Delete;
        }

        [Authorize(VietLifePermissions.NhomSanPham.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.NhomSanPham.View)]
        public async Task<List<NhomSanPhamInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => x.HieuLuc); // chỉ lấy hiệu lực
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<NhomSanPham>, List<NhomSanPhamInListDto>>(data);
        }

        [Authorize(VietLifePermissions.NhomSanPham.View)]
        public async Task<PagedResultDto<NhomSanPhamInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.TenNhom.Contains(input.Keyword) || x.MaNhom.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<NhomSanPhamInListDto>(totalCount,
                ObjectMapper.Map<List<NhomSanPham>, List<NhomSanPhamInListDto>>(data)
            );
        }
    }
}
