using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Manufacturers;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace VietLife.Catalog.Manufacturers
{
    [Authorize(VietLifePermissions.Manufacturer.Default,Policy ="AdminOnly")]
    public class ManufacturersAppService : CrudAppService<Manufacturer, ManufacturerDto, Guid, PagedResultRequestDto, CreateUpdateManufacturerDto, CreateUpdateManufacturerDto>,
        IManufacturersAppService
    {
        public ManufacturersAppService(IRepository<Manufacturer, Guid> repository) : base(repository)
        {
            GetPolicyName = VietLifePermissions.Manufacturer.Default;
            GetListPolicyName = VietLifePermissions.Manufacturer.Default;
            CreatePolicyName = VietLifePermissions.Manufacturer.Create;
            UpdatePolicyName = VietLifePermissions.Manufacturer.Update;
            DeletePolicyName = VietLifePermissions.Manufacturer.Delete;
        }

        [Authorize(VietLifePermissions.Manufacturer.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.Manufacturer.Default)]
        public async Task<List<ManufacturerInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => x.IsActive == true);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<Manufacturer>, List<ManufacturerInListDto>>(data);
        }

        [Authorize(VietLifePermissions.Manufacturer.Default)]
        public async Task<PagedResultDto<ManufacturerInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.Name.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<ManufacturerInListDto>(totalCount,
                ObjectMapper.Map<List<Manufacturer>, List<ManufacturerInListDto>>(data)
            );
        }
    }
}
