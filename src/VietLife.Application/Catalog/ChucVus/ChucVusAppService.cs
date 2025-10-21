using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Chucvus;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Catalog.ChucVus
{
    public class ChucVusAppService : CrudAppService<ChucVu, ChucVuDto, Guid, PagedResultRequestDto, CreateUpdateChucVuDto, CreateUpdateChucVuDto>,
        IChucVusAppService
    {
        public ChucVusAppService(IRepository<ChucVu, Guid> repository) : base(repository)
        {

        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<ChucVuInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<ChucVu>, List<ChucVuInListDto>>(data);
        }

        public async Task<PagedResultDto<ChucVuInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.TenChucVu.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<ChucVuInListDto>(totalCount,
                ObjectMapper.Map<List<ChucVu>, List<ChucVuInListDto>>(data)
            );
        }
    }
}
