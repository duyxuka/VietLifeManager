using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.ChiNhanhs;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace VietLife.Catalog.ChiNhanhs
{
    [Authorize(VietLifePermissions.ChiNhanh.Default)]
    public class ChiNhanhsAppService : CrudAppService<ChiNhanh, ChiNhanhDto, Guid, PagedResultRequestDto, CreateUpdateChiNhanhDto, CreateUpdateChiNhanhDto>,
        IChiNhanhsAppService
    {
        public ChiNhanhsAppService(IRepository<ChiNhanh, Guid> repository) : base(repository)
        {
            GetPolicyName = VietLifePermissions.ChiNhanh.Default;
            GetListPolicyName = VietLifePermissions.ChiNhanh.Default;
            CreatePolicyName = VietLifePermissions.ChiNhanh.Create;
            UpdatePolicyName = VietLifePermissions.ChiNhanh.Update;
            DeletePolicyName = VietLifePermissions.ChiNhanh.Delete;
        }

        [Authorize(VietLifePermissions.ChiNhanh.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.ChiNhanh.Default)]
        public async Task<List<ChiNhanhInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<ChiNhanh>, List<ChiNhanhInListDto>>(data);
        }

        [Authorize(VietLifePermissions.ChiNhanh.Default)]
        public async Task<PagedResultDto<ChiNhanhInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.TenChiNhanh.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<ChiNhanhInListDto>(totalCount,
                ObjectMapper.Map<List<ChiNhanh>, List<ChiNhanhInListDto>>(data)
            );
        }
    }
}
