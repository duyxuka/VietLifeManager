using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.ThuChisList.LoaiThuChis;
using VietLife.Catalog.ChucVus;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Business.ThuChis
{
    public class LoaiThuChisAppService :
        CrudAppService<LoaiThuChi, LoaiThuChiDto, Guid,
        PagedResultRequestDto, CreateUpdateLoaiThuChiDto, CreateUpdateLoaiThuChiDto>,
        ILoaiThuChisAppService
    {
        private readonly IRepository<LoaiThuChi, Guid> _repository;

        public LoaiThuChisAppService(IRepository<LoaiThuChi, Guid> repository)
            : base(repository)
        {
            _repository = repository;

            GetPolicyName = VietLifePermissions.ThuChi.View;
            GetListPolicyName = VietLifePermissions.ThuChi.View;
            CreatePolicyName = VietLifePermissions.ThuChi.Create;
            UpdatePolicyName = VietLifePermissions.ThuChi.Update;
            DeletePolicyName = VietLifePermissions.ThuChi.Delete;
        }
        [Authorize(VietLifePermissions.LoaiThuChi.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }
        [Authorize(VietLifePermissions.LoaiThuChi.View)]
        public async Task<List<LoaiThuChiInListDto>> GetListAllAsync()
        {
            var query = await _repository.GetQueryableAsync();
            var data = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<LoaiThuChi>, List<LoaiThuChiInListDto>>(data);
        }


        [Authorize(VietLifePermissions.LoaiThuChi.View)]
        public async Task<PagedResultDto<LoaiThuChiInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.Ten.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<LoaiThuChiInListDto>(totalCount,
                ObjectMapper.Map<List<LoaiThuChi>, List<LoaiThuChiInListDto>>(data)
            );
        }
    }
}
