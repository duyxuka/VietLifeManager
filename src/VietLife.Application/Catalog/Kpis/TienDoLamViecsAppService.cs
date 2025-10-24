using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.KPIs.MucTieuKpis;
using VietLife.Catalog.KPIs.TienDoLamViecs;
using VietLife.KPINhanViens;
using VietLife.NhanViens;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Catalog.Kpis
{
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
        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<TienDoLamViecInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<TienDoLamViec>, List<TienDoLamViecInListDto>>(data);
        }

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
        public override async Task<TienDoLamViecDto> CreateAsync(CreateUpdateTienDoLamViecDto input)
        {
            var entity = await base.CreateAsync(input);
            await CapNhatTienDo(input.KpiNhanVienId);
            return entity;
        }

        public override async Task<TienDoLamViecDto> UpdateAsync(Guid id, CreateUpdateTienDoLamViecDto input)
        {
            var entity = await base.UpdateAsync(id, input);
            await CapNhatTienDo(input.KpiNhanVienId);
            return entity;
        }

        private async Task CapNhatTienDo(Guid kpiId)
        {
            var tienDoList = await Repository.GetListAsync(x => x.KpiNhanVienId == kpiId);
            if (tienDoList.Any())
            {
                var avgTienDo = tienDoList.Average(x => x.PhanTramTienDo);
                var kpi = await _kpiNhanVienRepository.GetAsync(kpiId);
                kpi.PhanTramHoanThanh = avgTienDo; // hoặc cập nhật riêng trường “TienDoTrungBinh”
                kpi.TinhThuongKpi();
                await _kpiNhanVienRepository.UpdateAsync(kpi);
            }
        }

    }
}
