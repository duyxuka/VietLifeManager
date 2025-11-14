using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.HopDongs.LoaiHopDongs;
using VietLife.Catalog.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Catalog.HopDongs
{
    public class LoaiHopDongsAppService : CrudAppService<
        LoaiHopDong,
        LoaiHopDongDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateLoaiHopDongDto,
        CreateUpdateLoaiHopDongDto>,
        ILoaiHopDongsAppService
    {
        public LoaiHopDongsAppService(IRepository<LoaiHopDong, Guid> repository) : base(repository)
        {
            GetPolicyName = VietLifePermissions.LoaiHopDong.View;
            GetListPolicyName = VietLifePermissions.LoaiHopDong.View;
            CreatePolicyName = VietLifePermissions.LoaiHopDong.Create;
            UpdatePolicyName = VietLifePermissions.LoaiHopDong.Update;
            DeletePolicyName = VietLifePermissions.LoaiHopDong.Delete;
        }

        [Authorize(VietLifePermissions.LoaiHopDong.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.LoaiHopDong.View)]
        public async Task<List<LoaiHopDongInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<LoaiHopDong>, List<LoaiHopDongInListDto>>(data);
        }

        [Authorize(VietLifePermissions.LoaiHopDong.View)]
        public async Task<PagedResultDto<LoaiHopDongInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.TenLoai.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<LoaiHopDongInListDto>(totalCount,
                ObjectMapper.Map<List<LoaiHopDong>, List<LoaiHopDongInListDto>>(data)
            );
        }
    }
}
