using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.KPIs.KeHoachCongViecs;
using VietLife.Catalog.KPIs.MucTieuKpis;
using VietLife.KPINhanViens;
using VietLife.NhanViens;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Catalog.Kpis
{
    public class MucTieuKpisAppService : CrudAppService<
    MucTieuKpi,
    MucTieuKpiDto,
    Guid,
    PagedResultRequestDto,
    CreateUpdateMucTieuKpiDto,
    CreateUpdateMucTieuKpiDto>,
    IMucTieuKpisAppService
    {
        private readonly IRepository<KpiNhanVien, Guid> _kpiNhanVienRepository;
        private readonly IRepository<KeHoachCongViec, Guid> _keHoachCongViecRepository;

        public MucTieuKpisAppService(
            IRepository<MucTieuKpi, Guid> repository,
            IRepository<KpiNhanVien, Guid> kpiNhanVienRepository,
            IRepository<KeHoachCongViec, Guid> keHoachCongViecRepository
            
        ) : base(repository)
        {
            _kpiNhanVienRepository = kpiNhanVienRepository;
            _keHoachCongViecRepository = keHoachCongViecRepository;
            
        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<MucTieuKpiInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<MucTieuKpi>, List<MucTieuKpiInListDto>>(data);
        }

        public async Task<PagedResultDto<MucTieuKpiInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var mucTieuQuery = await Repository.GetQueryableAsync();
            var kpiQuery = await _kpiNhanVienRepository.GetQueryableAsync();
            var kehoachQuery = await _keHoachCongViecRepository.GetQueryableAsync();
           

            var query =
                from mt in mucTieuQuery
                join kpi in kpiQuery on mt.KpiNhanVienId equals kpi.Id into joinedKpi
                from kpi in joinedKpi.DefaultIfEmpty()
                join kehoach in kehoachQuery on mt.KeHoachCongViecId equals kehoach.Id into joinedKehoach
                from kehoach in joinedKehoach.DefaultIfEmpty()
                where !mt.IsDeleted
                orderby mt.CreationTime descending
                select new MucTieuKpiInListDto
                {
                    Id = mt.Id,
                    TenMucTieu = mt.TenMucTieu,
                    GiaTriMucTieu = mt.GiaTriMucTieu,
                    GiaTriThucHien = mt.GiaTriThucHien,
                    DonVi = mt.DonVi,
                    TrongSo = mt.TrongSo,
                    TenKpi = kpi != null ? $"{kpi.Thang}/{kpi.Nam}" : "N/A",
                    TenKeHoach = kehoach != null ? kehoach.TenKeHoach : "N/A"
                };

            // Nếu có từ khóa tìm kiếm (trong input.Keyword)
            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x =>
                    x.TenMucTieu.Contains(input.Keyword) ||
                    x.TenKeHoach.Contains(input.Keyword) ||
                    x.TenKpi.Contains(input.Keyword));
            }

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter
                .ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));

            return new PagedResultDto<MucTieuKpiInListDto>(totalCount, data);
        }

        public override async Task<MucTieuKpiDto> CreateAsync(CreateUpdateMucTieuKpiDto input)
        {
            var entity = await base.CreateAsync(input);
            await CapNhatKpiCha(input.KpiNhanVienId);
            return entity;
        }

        public override async Task<MucTieuKpiDto> UpdateAsync(Guid id, CreateUpdateMucTieuKpiDto input)
        {
            var entity = await base.UpdateAsync(id, input);
            await CapNhatKpiCha(input.KpiNhanVienId);
            return entity;
        }

        // 🔹 Hàm cập nhật lại KPI cha
        private async Task CapNhatKpiCha(Guid kpiId)
        {
            var mucTieuList = await Repository.GetListAsync(x => x.KpiNhanVienId == kpiId);
            if (mucTieuList.Any())
            {
                decimal tongTrongSo = mucTieuList.Sum(x => x.TrongSo);
                decimal tongDiem = 0;

                foreach (var mt in mucTieuList)
                {
                    // Ví dụ: hoàn thành = (thực hiện / mục tiêu) * trọng số
                    if (mt.GiaTriMucTieu > 0)
                        tongDiem += (mt.GiaTriThucHien / mt.GiaTriMucTieu) * mt.TrongSo;
                }

                var kpi = await _kpiNhanVienRepository.GetAsync(kpiId);
                kpi.TinhPhanTramHoanThanh(tongTrongSo, tongDiem);
                kpi.TinhThuongKpi();
                await _kpiNhanVienRepository.UpdateAsync(kpi);
            }
        }
    }
}
