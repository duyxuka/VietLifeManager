using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.KPIs.KeHoachCongViecs;
using VietLife.Catalog.KPIs.KpiNhanViens;
using VietLife.KPINhanViens;
using VietLife.NhanViens;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Catalog.Kpis
{
    public class KeHoachCongViecsAppService : CrudAppService<
        KeHoachCongViec,
        KeHoachCongViecDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateKeHoachCongViecDto,
        CreateUpdateKeHoachCongViecDto>,
        IKeHoachCongViecsAppService
    {
        private readonly IRepository<KpiNhanVien, Guid> _kpiNhanVienRepository;
        private readonly IRepository<MucTieuKpi, Guid> _mucTieuRepository;
        private readonly IRepository<NhanVien, Guid> _nhanVienRepository;

        public KeHoachCongViecsAppService(
            IRepository<KeHoachCongViec, Guid> repository,
            IRepository<KpiNhanVien, Guid> kpiNhanVienRepository,
            IRepository<MucTieuKpi, Guid> mucTieuRepository,
            IRepository<NhanVien, Guid> nhanVienRepository
        ) : base(repository)
        {
            _kpiNhanVienRepository = kpiNhanVienRepository;
            _mucTieuRepository = mucTieuRepository;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<KeHoachCongViecInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<KeHoachCongViec>, List<KeHoachCongViecInListDto>>(data);
        }

        public async Task<PagedResultDto<KeHoachCongViecInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var keHoachQuery = await Repository.GetQueryableAsync();
            var kpiQuery = await _kpiNhanVienRepository.GetQueryableAsync();
            var mucTieuQuery = await _mucTieuRepository.GetQueryableAsync();
            var nvQuery = await _nhanVienRepository.GetQueryableAsync();

            var query =
                from kh in keHoachQuery
                join kpi in kpiQuery on kh.KpiNhanVienId equals kpi.Id into joinedKpi
                from kpi in joinedKpi.DefaultIfEmpty()
                join nv in nvQuery on kpi.NhanVienId equals nv.Id into joinedNV
                from nv in joinedNV.DefaultIfEmpty()
                where !kh.IsDeleted
                orderby kh.CreationTime descending
                select new KeHoachCongViecInListDto
                {
                    Id = kh.Id,
                    KpiNhanVienId = kh.KpiNhanVienId,
                    TenKpi = kpi != null ? $"{kpi.Thang}/{kpi.Nam}" : "N/A",
                    TenKeHoach = kh.TenKeHoach,
                    MoTa = kh.MoTa,
                    NgayBatDau = kh.NgayBatDau,
                    NgayKetThuc = kh.NgayKetThuc,
                    TrongSo = kh.TrongSo,
                    // Đếm số mục tiêu thuộc kế hoạch này (subquery)
                    SoMucTieu = mucTieuQuery.Count(x => x.KeHoachCongViecId == kh.Id && !x.IsDeleted),
                    TenNhanVien = nv != null ? nv.HoTen : "N/A"
                };

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));

            return new PagedResultDto<KeHoachCongViecInListDto>(totalCount, data);
        }

        public override async Task<KeHoachCongViecDto> CreateAsync(CreateUpdateKeHoachCongViecDto input)
        {
            var entity = await base.CreateAsync(input);
            await CapNhatSoMucTieu(entity.Id);
            return entity;
        }

        public override async Task<KeHoachCongViecDto> UpdateAsync(Guid id, CreateUpdateKeHoachCongViecDto input)
        {
            var entity = await base.UpdateAsync(id, input);
            await CapNhatSoMucTieu(entity.Id);
            return entity;
        }

        private async Task CapNhatSoMucTieu(Guid keHoachId)
        {
            var mucTieuList = await _mucTieuRepository.GetListAsync(x => x.KeHoachCongViecId == keHoachId);
            var mucTieuCount = mucTieuList.Count;
            var keHoach = await Repository.GetAsync(keHoachId);
            keHoach.SoMucTieu = mucTieuCount;
            await Repository.UpdateAsync(keHoach);
        }
    }
}
