using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.HopDongs.HopDongNhanViens;
using VietLife.Catalog.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Catalog.HopDongs
{
    public class HopDongNhanViensAppService : CrudAppService<
        HopDongNhanVien,
        HopDongNhanVienDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateHopDongNhanVienDto,
        CreateUpdateHopDongNhanVienDto>,
        IHopDongNhanViensAppService
    {
        public HopDongNhanViensAppService(IRepository<HopDongNhanVien, Guid> repository) : base(repository)
        {
            GetPolicyName = VietLifePermissions.HopDongNhanVien.View;
            GetListPolicyName = VietLifePermissions.HopDongNhanVien.View;
            CreatePolicyName = VietLifePermissions.HopDongNhanVien.Create;
            UpdatePolicyName = VietLifePermissions.HopDongNhanVien.Update;
            DeletePolicyName = VietLifePermissions.HopDongNhanVien.Delete;
        }

        [Authorize(VietLifePermissions.HopDongNhanVien.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.HopDongNhanVien.View)]
        public async Task<List<HopDongNhanVienInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<HopDongNhanVien>, List<HopDongNhanVienInListDto>>(data);
        }

        [Authorize(VietLifePermissions.HopDongNhanVien.View)]
        public async Task<PagedResultDto<HopDongNhanVienInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.MaHopDong.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<HopDongNhanVienInListDto>(totalCount,
                ObjectMapper.Map<List<HopDongNhanVien>, List<HopDongNhanVienInListDto>>(data)
            );
        }
    }
}
