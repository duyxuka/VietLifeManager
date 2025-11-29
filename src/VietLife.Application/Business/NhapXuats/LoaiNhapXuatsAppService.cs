using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.NhapXuats.LoaiNhapXuats;
using VietLife.Business.PhieuNhapXuats;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Business.NhapXuats
{
    public class LoaiNhapXuatsAppService : CrudAppService<
        LoaiNhapXuat,
        LoaiNhapXuatDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateLoaiNhapXuatDto,
        CreateUpdateLoaiNhapXuatDto>,
    ILoaiNhapXuatsAppService
    {
        public LoaiNhapXuatsAppService(IRepository<LoaiNhapXuat, Guid> repository)
            : base(repository)
        {
            GetPolicyName = VietLifePermissions.LoaiNhapXuat.View;
            GetListPolicyName = VietLifePermissions.LoaiNhapXuat.View;
            CreatePolicyName = VietLifePermissions.LoaiNhapXuat.Create;
            UpdatePolicyName = VietLifePermissions.LoaiNhapXuat.Update;
            DeletePolicyName = VietLifePermissions.LoaiNhapXuat.Delete;
        }

        [Authorize(VietLifePermissions.LoaiNhapXuat.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.LoaiNhapXuat.View)]
        public async Task<List<LoaiNhapXuatInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var data = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<LoaiNhapXuat>, List<LoaiNhapXuatInListDto>>(data);
        }

        [Authorize(VietLifePermissions.LoaiNhapXuat.View)]
        public async Task<PagedResultDto<LoaiNhapXuatInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.TenLoai.Contains(input.Keyword));

            var total = await AsyncExecuter.LongCountAsync(query);
            var list = await AsyncExecuter.ToListAsync(
                query.Skip(input.SkipCount).Take(input.MaxResultCount));

            return new PagedResultDto<LoaiNhapXuatInListDto>(
                total,
                ObjectMapper.Map<List<LoaiNhapXuat>, List<LoaiNhapXuatInListDto>>(list));
        }
    }
}
