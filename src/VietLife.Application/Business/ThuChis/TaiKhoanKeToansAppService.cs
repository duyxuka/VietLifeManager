using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.ThuChisList.LoaiThuChis;
using VietLife.Business.ThuChisList.TaiKhoanKeToans;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Business.ThuChis
{
    public class TaiKhoanKeToansAppService :
        CrudAppService<TaiKhoanKeToan, TaiKhoanKeToanDto, Guid,
        PagedResultRequestDto, CreateUpdateTaiKhoanKeToanDto, CreateUpdateTaiKhoanKeToanDto>,
        ITaiKhoanKeToansAppService
    {
        private readonly IRepository<TaiKhoanKeToan, Guid> _repository;

        public TaiKhoanKeToansAppService(IRepository<TaiKhoanKeToan, Guid> repository)
            : base(repository)
        {
            _repository = repository;

            GetPolicyName = VietLifePermissions.TaiKhoanKeToan.View;
            GetListPolicyName = VietLifePermissions.TaiKhoanKeToan.View;
            CreatePolicyName = VietLifePermissions.TaiKhoanKeToan.Create;
            UpdatePolicyName = VietLifePermissions.TaiKhoanKeToan.Update;
            DeletePolicyName = VietLifePermissions.TaiKhoanKeToan.Delete;
        }

        [Authorize(VietLifePermissions.TaiKhoanKeToan.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.TaiKhoanKeToan.View)]
        public async Task<List<TaiKhoanKeToanInListDto>> GetListAllAsync()
        {
            var query = await _repository.GetQueryableAsync();
            var data = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<TaiKhoanKeToan>, List<TaiKhoanKeToanInListDto>>(data);
        }

        [Authorize(VietLifePermissions.TaiKhoanKeToan.View)]
        public async Task<PagedResultDto<TaiKhoanKeToanInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.TenTaiKhoan.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<TaiKhoanKeToanInListDto>(totalCount,
                ObjectMapper.Map<List<TaiKhoanKeToan>, List<TaiKhoanKeToanInListDto>>(data)
            );
        }
    }
}
