using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.ChamCongs;
using VietLife.Catalog.CheDoNhanViens;
using VietLife.Catalog.ChucVus;
using VietLife.Catalog.KPINhanViens;
using VietLife.Catalog.NhanViens;
using VietLife.Catalog.PhongBans;
using VietLife.Catalog.PhuCapNhanViens;
using VietLife.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Catalog.LuongNhanViens
{
    public class LuongNhanViensAppService : CrudAppService<
        LuongNhanVien,
        LuongNhanVienDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateLuongNhanVienDto,
        CreateUpdateLuongNhanVienDto>,
        ILuongNhanViensAppService
    {
        private readonly IRepository<ChamCong, Guid> _chamCongRepository;
        private readonly IRepository<NhanVien, Guid> _nhanVienRepository;
        private readonly IRepository<KpiNhanVien, Guid> _kpiRepository;
        private readonly IRepository<CheDoNhanVien, Guid> _cheDoRepository;
        private readonly IRepository<PhuCapNhanVien, Guid> _phuCapRepository;
        private readonly IRepository<HopDongNhanVien, Guid> _hopDongRepository;

        public LuongNhanViensAppService(
            IRepository<LuongNhanVien, Guid> repository,
            IRepository<ChamCong, Guid> chamCongRepository,
            IRepository<NhanVien, Guid> nhanVienRepository,
            IRepository<KpiNhanVien, Guid> kpiRepository,
            IRepository<CheDoNhanVien, Guid> cheDoRepository,
            IRepository<PhuCapNhanVien, Guid> phuCapRepository,
            IRepository<HopDongNhanVien, Guid> hopDongRepository)
            : base(repository)
        {
            _chamCongRepository = chamCongRepository;
            _nhanVienRepository = nhanVienRepository;
            _kpiRepository = kpiRepository;
            _cheDoRepository = cheDoRepository;
            _phuCapRepository = phuCapRepository;

            GetPolicyName = VietLifePermissions.LuongNhanVien.View;
            GetListPolicyName = VietLifePermissions.LuongNhanVien.View;
            CreatePolicyName = VietLifePermissions.LuongNhanVien.Create;
            UpdatePolicyName = VietLifePermissions.LuongNhanVien.Update;
            DeletePolicyName = VietLifePermissions.LuongNhanVien.Delete;
            _hopDongRepository = hopDongRepository;
        }

        [Authorize(VietLifePermissions.LuongNhanVien.View)]
        public async Task<List<LuongNhanVienInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<LuongNhanVien>, List<LuongNhanVienInListDto>>(data);
        }

        [Authorize(VietLifePermissions.LuongNhanVien.View)]
        public async Task<PagedResultDto<LuongNhanVienInListDto>> GetListFilterAsync(LuongNhanVienListFilterDto input)
        {
            var currentUserId = CurrentUser.Id;
            var isAdmin = await AuthorizationService.IsGrantedAsync(VietLifePermissions.LuongNhanVien.ViewAll);

            Guid? nhanVienIdFilter = input.NhanVienId;
            if (!isAdmin)
            {
                // Lấy nhân viên theo UserId của tài khoản hiện tại
                var nv = await _nhanVienRepository.FirstOrDefaultAsync(x => x.Id == currentUserId);
                if (nv == null) throw new AbpException("Không tìm thấy nhân viên cho tài khoản hiện tại.");

                nhanVienIdFilter = nv.Id; // luôn chỉ xem chính mình
            }

            if (input.NhanVienId.HasValue)
            {
                await TinhLuongNhanVienAsync(input.NhanVienId.Value);
            }
            else if (!isAdmin)
            {
                // Nếu user thường thì mặc định cũng tính lương của họ
                await TinhLuongNhanVienAsync(nhanVienIdFilter.Value);
            }

            var luongQuery = await Repository.GetQueryableAsync();
            var nvQuery = await _nhanVienRepository.GetQueryableAsync();

            var query =
                from luong in luongQuery
                join nv in nvQuery on luong.NhanVienId equals nv.Id into nvJoin
                from nv in nvJoin.DefaultIfEmpty()
                where !luong.IsDeleted

                // Filter khi user không phải admin
                where !isAdmin ? luong.NhanVienId == nhanVienIdFilter : true

                // Filter khi admin chọn nhân viên trong dropdown
                where input.NhanVienId != null && input.NhanVienId != Guid.Empty
                    ? luong.NhanVienId == input.NhanVienId
                    : true

                // Keyword
                where string.IsNullOrWhiteSpace(input.Keyword)
                    || (nv != null && nv.HoTen.Contains(input.Keyword))

                // Tháng
                where (input.Thang > 0 ? luong.Thang == input.Thang : true)

                // Năm
                where (input.Nam > 0 ? luong.Nam == input.Nam : true)

                orderby luong.CreationTime descending

                select new LuongNhanVienInListDto
                {
                    Id = luong.Id,
                    NhanVienId = luong.NhanVienId,
                    TenNhanVien = nv != null ? nv.HoTen : "N/A",
                    Thang = luong.Thang,
                    Nam = luong.Nam,
                    LuongTheoNgayCong = luong.LuongTheoNgayCong,
                    PhuCap = luong.PhuCap,
                    ThuongKpi = luong.ThuongKpi,
                    ThuongKhac = luong.ThuongKhac,
                    KhauTru = luong.KhauTru,
                    CongTruCheDo = luong.CongTruCheDo,
                    TongLuong = luong.TongLuong,
                    NgayTinhLuong = luong.NgayTinhLuong,
                    NguoiTinhLuongId = luong.NguoiTinhLuongId,
                    GhiChu = luong.GhiChu
                };

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var data = await AsyncExecuter
                .ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));

            return new PagedResultDto<LuongNhanVienInListDto>(totalCount, data);
        }


        [Authorize(VietLifePermissions.LuongNhanVien.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.LuongNhanVien.View)]
        private async Task TinhLuongNhanVienAsync(Guid nhanVienId)
        {
            var today = DateTime.Today;
            var month = today.Month;
            var year = today.Year;

            var nv = await _nhanVienRepository.FirstOrDefaultAsync(x => x.Id == nhanVienId);
            if (nv == null) return;

            var hopDong = await _hopDongRepository
                .FirstOrDefaultAsync(hd => hd.NhanVienId == nhanVienId && hd.LaHienHanh);

            if (hopDong == null) return;

            var luong = await Repository.FirstOrDefaultAsync(x =>
                x.NhanVienId == nhanVienId && x.Thang == month && x.Nam == year);

            bool isNew = luong == null;
            if (isNew)
            {
                luong = new LuongNhanVien
                {
                    NhanVienId = nhanVienId,
                    Thang = month,
                    Nam = year,
                    NgayTinhLuong = DateTime.Now
                };
            }

            var chamCongs = await _chamCongRepository.GetListAsync(x =>
                x.NhanVienId == nhanVienId &&
                x.NgayLam.Month == month &&
                x.NgayLam.Year == year);

            var tongCongNgay = chamCongs.Sum(x => x.CongNgay ?? 0);
            luong.LuongTheoNgayCong = tongCongNgay * hopDong.DonGiaCong;

            var tongPhutTre = chamCongs.Sum(x => x.SoPhutDiMuon ?? 0);
            var tongPhutSom = chamCongs.Sum(x => x.SoPhutVeSom ?? 0);
            var luongPhut = hopDong.LuongCoBan / (26 * 8 * 60);
            luong.KhauTru = (tongPhutTre + tongPhutSom) * luongPhut;

            var phuCaps = await _phuCapRepository.GetListAsync(x => x.ChucVuId == nv.ChucVuId);
            luong.PhuCap = phuCaps.Sum(x => x.SoTien);

            var kpi = await _kpiRepository.FirstOrDefaultAsync(x =>
                x.NhanVienId == nhanVienId && x.Thang == month && x.Nam == year);
            luong.ThuongKpi = kpi?.ThuongKpi ?? 0;

            var cheDos = await _cheDoRepository.GetListAsync(x =>
                x.NhanVienId == nhanVienId &&
                x.NgayBatDau.Value.Month == month &&
                x.NgayBatDau.Value.Year == year &&
                x.TrangThai == true);
            luong.CongTruCheDo = cheDos.Sum(x => x.ThanhTien ?? 0);

            luong.TinhTongLuong(hopDong);

            if (isNew)
                await Repository.InsertAsync(luong);
            else
                await Repository.UpdateAsync(luong);
        }

    }
}
