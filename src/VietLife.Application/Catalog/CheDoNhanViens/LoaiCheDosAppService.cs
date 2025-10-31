using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.CheDos.LoaiCheDos;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace VietLife.Catalog.CheDoNhanViens
{
    public class LoaiCheDosAppService : CrudAppService<LoaiCheDo, LoaiCheDoDto, Guid, PagedResultRequestDto, CreateUpdateLoaiCheDoDto, CreateUpdateLoaiCheDoDto>,
        ILoaiCheDosAppService
    {
        public LoaiCheDosAppService(IRepository<LoaiCheDo, Guid> repository) : base(repository)
        {
            GetPolicyName = VietLifePermissions.LoaiCheDo.View;
            GetListPolicyName = VietLifePermissions.LoaiCheDo.View;
            CreatePolicyName = VietLifePermissions.LoaiCheDo.Create;
            UpdatePolicyName = VietLifePermissions.LoaiCheDo.Update;
            DeletePolicyName = VietLifePermissions.LoaiCheDo.Delete;
        }

        [Authorize(VietLifePermissions.LoaiCheDo.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.LoaiCheDo.View)]
        public async Task<List<LoaiCheDoInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<LoaiCheDo>, List<LoaiCheDoInListDto>>(data);
        }

        [Authorize(VietLifePermissions.LoaiCheDo.View)]
        public async Task<PagedResultDto<LoaiCheDoInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.TenLoaiCheDo.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<LoaiCheDoInListDto>(totalCount,
                ObjectMapper.Map<List<LoaiCheDo>, List<LoaiCheDoInListDto>>(data)
            );
        }
    }
}
