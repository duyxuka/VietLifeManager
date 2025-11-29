using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.KhachHangs;
using VietLife.Business.KhoHangs;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Business.ThanhPhos
{
    public class ThanhPhosAppService :
        CrudAppService<ThanhPho, ThanhPhoDto, Guid, PagedResultRequestDto, CreateUpdateThanhPhoDto, CreateUpdateThanhPhoDto>,
        IThanhPhosAppService
    {
        private readonly IRepository<ThanhPho, Guid> _repository;
        private readonly IRepository<KhoHang, Guid> _khoHangRepository;
        private readonly IRepository<KhachHang, Guid> _khachHangRepository;

        public ThanhPhosAppService(IRepository<ThanhPho, Guid> repository,
            IRepository<KhoHang, Guid> khoHangRepository,
            IRepository<KhachHang, Guid> khachHangRepository) : base(repository)
        {
            _repository = repository;
            _khoHangRepository = khoHangRepository;
            _khachHangRepository = khachHangRepository;

            GetPolicyName = VietLifePermissions.ThanhPho.View;
            GetListPolicyName = VietLifePermissions.ThanhPho.View;
            CreatePolicyName = VietLifePermissions.ThanhPho.Create;
            UpdatePolicyName = VietLifePermissions.ThanhPho.Update;
            DeletePolicyName = VietLifePermissions.ThanhPho.Delete;
        }

        [Authorize(VietLifePermissions.ThanhPho.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await _repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.ThanhPho.View)]
        public async Task<List<ThanhPhoInListDto>> GetListAllAsync()
        {
            var query = await _repository.GetQueryableAsync();
            var data = await AsyncExecuter.ToListAsync(query);

            return await MapToInListDtoAsync(data);
        }

        [Authorize(VietLifePermissions.ThanhPho.View)]
        public async Task<PagedResultDto<ThanhPhoInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await _repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.Ten.Contains(input.Keyword) || x.MaVung.Contains(input.Keyword));

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var finalData = await MapToInListDtoAsync(data);

            return new PagedResultDto<ThanhPhoInListDto>(totalCount, finalData);
        }
        private async Task<List<ThanhPhoInListDto>> MapToInListDtoAsync(List<ThanhPho> thanhPhos)
        {
            if (thanhPhos == null || !thanhPhos.Any())
                return new List<ThanhPhoInListDto>();

            var thanhPhoIds = thanhPhos.Select(x => x.Id).ToList();

            var khoHangQuery = await _khoHangRepository.GetQueryableAsync();
            var khachHangQuery = await _khachHangRepository.GetQueryableAsync();

            // Lấy số kho hàng theo từng thành phố
            var khoHangList = await AsyncExecuter.ToListAsync(
                khoHangQuery
                    .Where(x => x.ThanhPhoId != null && thanhPhoIds.Contains(x.ThanhPhoId.Value))
                    .GroupBy(x => x.ThanhPhoId)
                    .Select(g => new { ThanhPhoId = g.Key!.Value, Count = g.Count() })
            );

            var khoHangCounts = khoHangList.ToDictionary(x => x.ThanhPhoId, x => x.Count);

            // Lấy số khách hàng theo từng thành phố
            var khachHangList = await AsyncExecuter.ToListAsync(
                khachHangQuery
                    .Where(x => x.ThanhPhoId != null && thanhPhoIds.Contains(x.ThanhPhoId.Value))
                    .GroupBy(x => x.ThanhPhoId)
                    .Select(g => new { ThanhPhoId = g.Key!.Value, Count = g.Count() })
            );

            var khachHangCounts = khachHangList.ToDictionary(x => x.ThanhPhoId, x => x.Count);

            // Map sang DTO
            return thanhPhos.Select(tp => new ThanhPhoInListDto
            {
                Id = tp.Id,
                Ten = tp.Ten,
                MaVung = tp.MaVung,
                KhoHangCount = khoHangCounts.ContainsKey(tp.Id) ? khoHangCounts[tp.Id] : 0,
                KhachHangCount = khachHangCounts.ContainsKey(tp.Id) ? khachHangCounts[tp.Id] : 0

            }).ToList();
        }
    }
}
