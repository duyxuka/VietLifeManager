using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.ChiNhanhs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace VietLife.Catalog.ChiNhanhs
{
    public class ChiNhanhsAppService : CrudAppService<ChiNhanh, ChiNhanhDto, Guid, PagedResultRequestDto, CreateUpdateChiNhanhDto, CreateUpdateChiNhanhDto>,
        IChiNhanhsAppService
    {
        public ChiNhanhsAppService(IRepository<ChiNhanh, Guid> repository) : base(repository)
        {

        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<ChiNhanhInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<ChiNhanh>, List<ChiNhanhInListDto>>(data);
        }

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
