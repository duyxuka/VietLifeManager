using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.KPIs.MucTieuKpis;
using VietLife.Catalog.KPIs.TienDoLamViecs;
using VietLife.KPINhanViens;
using VietLife.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Catalog.Kpis
{
    [Authorize(VietLifePermissions.KpiNhanVien.TienDoLamViec.Default)]
    public class TienDoLamViecsAppService : CrudAppService<
    TienDoLamViec,
    TienDoLamViecDto,
    Guid,
    PagedResultRequestDto,
    CreateUpdateTienDoLamViecDto,
    CreateUpdateTienDoLamViecDto>,
    ITienDoLamViecsAppService
    {
        private readonly IRepository<KpiNhanVien, Guid> _kpiNhanVienRepository;
        private readonly IRepository<NhanVien, Guid> _nhanVienRepository;

        public TienDoLamViecsAppService(
            IRepository<TienDoLamViec, Guid> repository,
            IRepository<KpiNhanVien, Guid> kpiNhanVienRepository,
            IRepository<NhanVien, Guid> nhanVienRepository
        ) : base(repository)
        {
            _kpiNhanVienRepository = kpiNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;

            GetPolicyName = VietLifePermissions.KpiNhanVien.TienDoLamViec.Default;
            GetListPolicyName = VietLifePermissions.KpiNhanVien.TienDoLamViec.Default;
            CreatePolicyName = VietLifePermissions.KpiNhanVien.TienDoLamViec.Create;
            UpdatePolicyName = VietLifePermissions.KpiNhanVien.TienDoLamViec.Update;
            DeletePolicyName = VietLifePermissions.KpiNhanVien.TienDoLamViec.Delete;
        }

        [Authorize(VietLifePermissions.KpiNhanVien.TienDoLamViec.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.KpiNhanVien.TienDoLamViec.Default)]
        public async Task<List<TienDoLamViecInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<TienDoLamViec>, List<TienDoLamViecInListDto>>(data);
        }

        [Authorize(VietLifePermissions.KpiNhanVien.TienDoLamViec.Default)]
        public async Task<PagedResultDto<TienDoLamViecInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var tienDoQuery = await Repository.GetQueryableAsync();
            var kpiQuery = await _kpiNhanVienRepository.GetQueryableAsync();
            var nvQuery = await _nhanVienRepository.GetQueryableAsync();

            var query = from td in tienDoQuery
                        join kpi in kpiQuery on td.KpiNhanVienId equals kpi.Id into joinedKpi
                        from kpi in joinedKpi.DefaultIfEmpty()
                        join nv in nvQuery on kpi.NhanVienId equals nv.Id into joinedNV
                        from nv in joinedNV.DefaultIfEmpty()
                        where !td.IsDeleted
                        orderby td.NgayCapNhat descending
                        select new TienDoLamViecInListDto
                        {
                            Id = td.Id,
                            NgayCapNhat = td.NgayCapNhat,
                            PhanTramTienDo = td.PhanTramTienDo,
                            GhiChu = td.GhiChu,
                            TenKpi = kpi != null ? $"{kpi.Thang}/{kpi.Nam}" : "N/A",
                            TenNhanVien = nv != null ? nv.HoTen : "N/A"
                        };

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));

            return new PagedResultDto<TienDoLamViecInListDto>(totalCount, data);
        }

        [Authorize(VietLifePermissions.KpiNhanVien.TienDoLamViec.Create)]
        public override async Task<TienDoLamViecDto> CreateAsync(CreateUpdateTienDoLamViecDto input)
        {
            var entity = await base.CreateAsync(input);
            await CapNhatTienDo(input.KpiNhanVienId);
            return entity;
        }

        [Authorize(VietLifePermissions.KpiNhanVien.TienDoLamViec.Update)]
        public override async Task<TienDoLamViecDto> UpdateAsync(Guid id, CreateUpdateTienDoLamViecDto input)
        {
            var entity = await base.UpdateAsync(id, input);
            await CapNhatTienDo(input.KpiNhanVienId);
            return entity;
        }

        private async Task CapNhatTienDo(Guid kpiId)
        {
            var tienDoList = await Repository.GetListAsync(x => x.KpiNhanVienId == kpiId && !x.IsDeleted);
            if (tienDoList == null || !tienDoList.Any()) return;

            var avgTienDo = tienDoList
                .Where(x => x.PhanTramTienDo.HasValue)
                .Average(x => x.PhanTramTienDo.Value);

            var kpi = await _kpiNhanVienRepository.GetAsync(kpiId);
            if (kpi == null) return;

            kpi.PhanTramHoanThanh = Math.Round(avgTienDo, 2);
            kpi.TinhThuongKpi();

            await _kpiNhanVienRepository.UpdateAsync(kpi, autoSave: true);
        }

    }
}
