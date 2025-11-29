using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.ChucVus;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Business.TienTes
{
    public class TienTesAppService :
        CrudAppService<TienTe, TienTeDto, Guid, PagedResultRequestDto, CreateUpdateTienTeDto, CreateUpdateTienTeDto>,
        ITienTesAppService
    {
        private readonly IRepository<TienTe, Guid> _repository;

        public TienTesAppService(IRepository<TienTe, Guid> repository)
            : base(repository)
        {
            _repository = repository;

            GetPolicyName = VietLifePermissions.TienTe.View;
            GetListPolicyName = VietLifePermissions.TienTe.View;
            CreatePolicyName = VietLifePermissions.TienTe.Create;
            UpdatePolicyName = VietLifePermissions.TienTe.Update;
            DeletePolicyName = VietLifePermissions.TienTe.Delete;
        }

        [Authorize(VietLifePermissions.TienTe.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.TienTe.View)]
        public async Task<List<TienTeInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<TienTe>, List<TienTeInListDto>>(data);
        }

        [Authorize(VietLifePermissions.TienTe.View)]
        public async Task<PagedResultDto<TienTeInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = from tt in await _repository.GetQueryableAsync()
                        select new TienTeInListDto
                        {
                            Id = tt.Id,
                            TenTienTe = tt.TenTienTe,
                            MaTienTe = tt.MaTienTe,
                            TyGia = tt.TyGia,
                            MacDinh = tt.MacDinh
                        };

            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x =>
                    x.TenTienTe.Contains(input.Keyword) ||
                    x.MaTienTe.Contains(input.Keyword));
            }

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(
                query.Skip(input.SkipCount).Take(input.MaxResultCount)
            );

            return new PagedResultDto<TienTeInListDto>(totalCount, data);
        }
    }
}
