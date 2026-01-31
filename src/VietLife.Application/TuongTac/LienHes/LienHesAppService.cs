using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Permissions;
using VietLife.TuongTac.LienHes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.TuongTac.LienHes
{
    public class LienHesAppService :
        CrudAppService<LienHe, LienHeDto, Guid, PagedResultRequestDto, CreateUpdateLienHeDto, CreateUpdateLienHeDto>,
        ILienHesAppService
    {
        public LienHesAppService(IRepository<LienHe, Guid> repository) : base(repository)
        {
            GetPolicyName = VietLifePermissions.LienHe.View;
            GetListPolicyName = VietLifePermissions.LienHe.View;
            CreatePolicyName = null;
            UpdatePolicyName = VietLifePermissions.LienHe.Update;
            DeletePolicyName = VietLifePermissions.LienHe.Delete;
        }

        [Authorize(VietLifePermissions.LienHe.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.LienHe.View)]
        public async Task<List<LienHeInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<LienHe>, List<LienHeInListDto>>(data);
        }

        [Authorize(VietLifePermissions.LienHe.View)]
        public async Task<PagedResultDto<LienHeInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.HoVaTen.Contains(input.Keyword)).WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.SoDienThoai.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<LienHeInListDto>(totalCount,
                ObjectMapper.Map<List<LienHe>, List<LienHeInListDto>>(data)
            );
        }

        [AllowAnonymous]
        public override async Task<LienHeDto> CreateAsync(CreateUpdateLienHeDto input)
        {
            var entity = ObjectMapper.Map<CreateUpdateLienHeDto, LienHe>(input);

            entity.TrangThai = false;

            await Repository.InsertAsync(entity, autoSave: true);

            return ObjectMapper.Map<LienHe, LienHeDto>(entity);
        }
    }
}
