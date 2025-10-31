using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.CheDos.CheDoNhanViens;
using VietLife.Catalog.KPINhanViens;
using VietLife.Catalog.KPIs.KpiNhanViens;
using VietLife.Catalog.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace VietLife.Catalog.Kpis
{
    public class KpiNhanViensAppService : CrudAppService<
        KpiNhanVien,
        KpiNhanVienDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateKpiNhanVienDto,
        CreateUpdateKpiNhanVienDto>,
        IKpiNhanViensAppService
    {
        private readonly IRepository<NhanVien, Guid> _nhanVienRepository;
        private readonly IRepository<KeHoachCongViec, Guid> _keHoachRepository;
        private readonly IRepository<MucTieuKpi, Guid> _mucTieuRepository;

        public KpiNhanViensAppService(
            IRepository<KpiNhanVien, Guid> repository,
            IRepository<NhanVien, Guid> nhanVienRepository,
            IRepository<KeHoachCongViec, Guid> keHoachRepository,
            IRepository<MucTieuKpi, Guid> mucTieuRepository
        ) : base(repository)
        {
            _nhanVienRepository = nhanVienRepository;
            _keHoachRepository = keHoachRepository;
            _mucTieuRepository = mucTieuRepository;

            GetPolicyName = VietLifePermissions.KpiNhanVien.View;
            GetListPolicyName = VietLifePermissions.KpiNhanVien.View;
            CreatePolicyName = VietLifePermissions.KpiNhanVien.Create;
            UpdatePolicyName = VietLifePermissions.KpiNhanVien.Update;
            DeletePolicyName = VietLifePermissions.KpiNhanVien.Delete;
        }

        [Authorize(VietLifePermissions.KpiNhanVien.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.KpiNhanVien.View)]
        public async Task<List<KpiNhanVienInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<KpiNhanVien>, List<KpiNhanVienInListDto>>(data);
        }

        [Authorize(VietLifePermissions.KpiNhanVien.View)]
        public async Task<PagedResultDto<KpiNhanVienInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var kpiQuery = await Repository.GetQueryableAsync();
            var nvQuery = await _nhanVienRepository.GetQueryableAsync();

            var query = from kpi in kpiQuery
                        join nv in nvQuery on kpi.NhanVienId equals nv.Id into nvJoin
                        from nv in nvJoin.DefaultIfEmpty()
                        join dg in nvQuery on kpi.NguoiDanhGiaId equals dg.Id into dgJoin
                        from dg in dgJoin.DefaultIfEmpty()
                        where !kpi.IsDeleted
                        orderby kpi.CreationTime descending
                        select new KpiNhanVienInListDto
                        {
                            Id = kpi.Id,
                            NhanVienId = kpi.NhanVienId,
                            TenNhanVien = nv != null ? nv.HoTen : "N/A",
                            NguoiDanhGiaId = kpi.NguoiDanhGiaId,
                            TenNguoiDanhGia = dg != null ? dg.HoTen : "N/A",
                            Thang = kpi.Thang,
                            Nam = kpi.Nam,
                            MucLuongKpi = kpi.MucLuongKpi,
                            PhanTramHoanThanh = kpi.PhanTramHoanThanh,
                            DiemKpi = kpi.DiemKpi,
                            MucXepLoai = kpi.MucXepLoai,
                            ThuongKpi = kpi.ThuongKpi,
                            GhiChu = kpi.GhiChu
                        };

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));

            return new PagedResultDto<KpiNhanVienInListDto>(totalCount, data);
        }

        [Authorize(VietLifePermissions.KpiNhanVien.Create)]
        public override async Task<KpiNhanVienDto> CreateAsync(CreateUpdateKpiNhanVienDto input)
        {
            var entity = await MapToEntityAsync(input);

            // Người đánh giá mặc định là user hiện tại
            if (CurrentUser.Id.HasValue)
                entity.NguoiDanhGiaId = CurrentUser.Id.Value;

            entity.TinhThuongKpi();

            await Repository.InsertAsync(entity);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(VietLifePermissions.KpiNhanVien.Update)]
        public override async Task<KpiNhanVienDto> UpdateAsync(Guid id, CreateUpdateKpiNhanVienDto input)
        {
            var entity = await GetEntityByIdAsync(id);
            await MapToEntityAsync(input, entity);

            entity.TinhThuongKpi();
            await Repository.UpdateAsync(entity);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return await MapToGetOutputDtoAsync(entity);
        }
    }
}
