using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.KPIs.DanhGiaKpis;
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
    public class DanhGiaKpisAppService : CrudAppService<
    DanhGiaKpi,
    DanhGiaKpiDto,
    Guid,
    PagedResultRequestDto,
    CreateUpdateDanhGiaKpiDto,
    CreateUpdateDanhGiaKpiDto>,
    IDanhGiaKpisAppService
    {
        private readonly IRepository<KpiNhanVien, Guid> _kpiNhanVienRepository;
        private readonly IRepository<NhanVien, Guid> _nhanVienRepository;
        public DanhGiaKpisAppService(
            IRepository<DanhGiaKpi, Guid> repository,
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

        public async Task<List<DanhGiaKpiInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<DanhGiaKpi>, List<DanhGiaKpiInListDto>>(data);
        }

        public async Task<PagedResultDto<DanhGiaKpiInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var danhGiaQuery = await Repository.GetQueryableAsync();
            var kpiQuery = await _kpiNhanVienRepository.GetQueryableAsync();
            var nvQuery = await _nhanVienRepository.GetQueryableAsync();

            var query = from dg in danhGiaQuery
                        join kpi in kpiQuery on dg.KpiNhanVienId equals kpi.Id into joinedKpi
                        from kpi in joinedKpi.DefaultIfEmpty()
                        join nv in nvQuery on kpi.NhanVienId equals nv.Id into joinedNV
                        from nv in joinedNV.DefaultIfEmpty()
                        join nguoiDanhGia in nvQuery on dg.NguoiDanhGiaId equals nguoiDanhGia.Id into joinedNguoiDG
                        from nguoiDanhGia in joinedNguoiDG.DefaultIfEmpty()
                        where !dg.IsDeleted
                        orderby dg.CreationTime descending
                        select new DanhGiaKpiInListDto
                        {
                            Id = dg.Id,
                            DiemDanhGia = dg.DiemDanhGia,
                            NhanXet = dg.NhanXet,
                            TenKpi = kpi != null ? $"{kpi.Thang}/{kpi.Nam}" : "N/A",
                            TenNhanVien = nv != null ? nv.HoTen : "N/A",
                            TenNguoiDanhGia = nguoiDanhGia != null ? nguoiDanhGia.HoTen : "N/A"
                        };

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));

            return new PagedResultDto<DanhGiaKpiInListDto>(totalCount, data);
        }

        public override async Task<DanhGiaKpiDto> CreateAsync(CreateUpdateDanhGiaKpiDto input)
        {
            var entity = await base.CreateAsync(input);
            await CapNhatDiemKpi(input.KpiNhanVienId);
            return entity;
        }

        public override async Task<DanhGiaKpiDto> UpdateAsync(Guid id, CreateUpdateDanhGiaKpiDto input)
        {
            var entity = await base.UpdateAsync(id, input);
            await CapNhatDiemKpi(input.KpiNhanVienId);
            return entity;
        }

        // 🔹 Hàm cập nhật điểm trung bình KPI
        private async Task CapNhatDiemKpi(Guid kpiId)
        {
            var danhGiaList = await Repository.GetListAsync(x => x.KpiNhanVienId == kpiId && x.DiemDanhGia.HasValue);
            if (danhGiaList.Any())
            {
                var diemTrungBinh = danhGiaList.Average(x => x.DiemDanhGia.Value);
                var kpi = await _kpiNhanVienRepository.GetAsync(kpiId);
                kpi.DiemKpi = diemTrungBinh;
                await _kpiNhanVienRepository.UpdateAsync(kpi);
            }
        }
    }
}
