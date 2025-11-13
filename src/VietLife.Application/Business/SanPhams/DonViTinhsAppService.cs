using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.SanPhamsList.DonViTinhs;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Business.SanPhams
{
    public class DonViTinhsAppService :
        CrudAppService<DonViTinh, DonViTinhDto, Guid, PagedResultRequestDto, CreateUpdateDonViTinhDto, CreateUpdateDonViTinhDto>,
        IDonViTinhsAppService
    {
        public DonViTinhsAppService(IRepository<DonViTinh, Guid> repository) : base(repository)
        {
            GetPolicyName = VietLifePermissions.DonViTinh.View;
            GetListPolicyName = VietLifePermissions.DonViTinh.View;
            CreatePolicyName = VietLifePermissions.DonViTinh.Create;
            UpdatePolicyName = VietLifePermissions.DonViTinh.Update;
            DeletePolicyName = VietLifePermissions.DonViTinh.Delete;
        }

        [Authorize(VietLifePermissions.DonViTinh.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.DonViTinh.View)]
        public async Task<List<DonViTinhInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<DonViTinh>, List<DonViTinhInListDto>>(data);
        }

        [Authorize(VietLifePermissions.DonViTinh.View)]
        public async Task<PagedResultDto<DonViTinhInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.TenDonVi.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<DonViTinhInListDto>(totalCount,
                ObjectMapper.Map<List<DonViTinh>, List<DonViTinhInListDto>>(data)
            );
        }
    }
}
