using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.DonHangsList.LoaiDonHangs;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Business.DonHangs
{
    public class LoaiDonHangsAppService : CrudAppService<
        LoaiDonHang,
        LoaiDonHangDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateLoaiDonHangDto,
        CreateUpdateLoaiDonHangDto>,
    ILoaiDonHangsAppService
    {
        public LoaiDonHangsAppService(IRepository<LoaiDonHang, Guid> repository)
            : base(repository)
        {
            GetPolicyName = VietLifePermissions.LoaiDonHang.View;
            GetListPolicyName = VietLifePermissions.LoaiDonHang.View;
            CreatePolicyName = VietLifePermissions.LoaiDonHang.Create;
            UpdatePolicyName = VietLifePermissions.LoaiDonHang.Update;
            DeletePolicyName = VietLifePermissions.LoaiDonHang.Delete;
        }

        [Authorize(VietLifePermissions.LoaiDonHang.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.LoaiDonHang.View)]
        public async Task<List<LoaiDonHangInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var data = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<LoaiDonHang>, List<LoaiDonHangInListDto>>(data);
        }

        [Authorize(VietLifePermissions.LoaiDonHang.View)]
        public async Task<PagedResultDto<LoaiDonHangInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.TenLoai.Contains(input.Keyword));

            var total = await AsyncExecuter.LongCountAsync(query);
            var list = await AsyncExecuter.ToListAsync(
                query.Skip(input.SkipCount).Take(input.MaxResultCount));

            return new PagedResultDto<LoaiDonHangInListDto>(
                total,
                ObjectMapper.Map<List<LoaiDonHang>, List<LoaiDonHangInListDto>>(list));
        }
    }
}
