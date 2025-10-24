using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.ChucVus;
using VietLife.Catalog.PhongBans;
using VietLife.ChamCongs;
using VietLife.CheDoNhanViens;
using VietLife.Chucvus;
using VietLife.KPINhanViens;
using VietLife.LuongNhanViens;
using VietLife.NhanViens;
using VietLife.PhuCapNhanViens;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public LuongNhanViensAppService(
            IRepository<LuongNhanVien, Guid> repository,
            IRepository<ChamCong, Guid> chamCongRepository,
            IRepository<NhanVien, Guid> nhanVienRepository,
            IRepository<KpiNhanVien, Guid> kpiRepository,
            IRepository<CheDoNhanVien, Guid> cheDoRepository,
            IRepository<PhuCapNhanVien, Guid> phuCapRepository)
            : base(repository)
        {
            _chamCongRepository = chamCongRepository;
            _nhanVienRepository = nhanVienRepository;
            _kpiRepository = kpiRepository;
            _cheDoRepository = cheDoRepository;
            _phuCapRepository = phuCapRepository;
        }

        public async Task<List<LuongNhanVienInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<LuongNhanVien>, List<LuongNhanVienInListDto>>(data);
        }

        public async Task<PagedResultDto<LuongNhanVienInListDto>> GetListFilterAsync(LuongNhanVienListFilterDto input)
        {
            var luongQuery = await Repository.GetQueryableAsync();
            var nvQuery = await _nhanVienRepository.GetQueryableAsync();

            var query = from luong in luongQuery
                        join nv in nvQuery on luong.NhanVienId equals nv.Id into nvJoin
                        from nv in nvJoin.DefaultIfEmpty()
                        where !luong.IsDeleted
                        where string.IsNullOrWhiteSpace(input.Keyword) || (nv != null && nv.HoTen.Contains(input.Keyword))
                        where input.NhanVienId == Guid.Empty || luong.NhanVienId == input.NhanVienId
                        where input.Thang <= 0 || luong.Thang == input.Thang
                        where input.Nam <= 0 || luong.Nam == input.Nam
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



        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [UnitOfWork]
        public async Task TinhLuongHangNgayAsync()
        {
            var nhanViens = await _nhanVienRepository.GetListAsync();

            foreach (var nv in nhanViens)
            {
                var today = DateTime.Today;
                var month = today.Month;
                var year = today.Year;

                var chamCongs = await _chamCongRepository.GetListAsync(x =>
                    x.NhanVienId == nv.Id &&
                    x.NgayLam.Month == month &&
                    x.NgayLam.Year == year);

                var luong = await Repository.FirstOrDefaultAsync(x =>
                    x.NhanVienId == nv.Id &&
                    x.Thang == month &&
                    x.Nam == year);

                bool isNew = luong == null;
                if (isNew)
                {
                    luong = new LuongNhanVien
                    {
                        NhanVienId = nv.Id,
                        Thang = month,
                        Nam = year,
                        NgayTinhLuong = DateTime.Now
                    };
                }

                // Tính lương theo công
                var tongCongNgay = chamCongs.Sum(x => x.CongNgay ?? 0);
                luong.LuongTheoNgayCong = tongCongNgay * nv.DonGiaCong; // ví dụ 100k/công

                // Tính khấu trừ đi muộn / về sớm
                var tongPhutTre = chamCongs.Sum(x => x.SoPhutDiMuon ?? 0);
                var tongPhutSom = chamCongs.Sum(x => x.SoPhutVeSom ?? 0);
                var luongTheoPhut = nv.LuongCoBan / (26 * 8 * 60); // 26 ngày * 8h * 60 phút
                luong.KhauTru = (tongPhutTre + tongPhutSom) * luongTheoPhut;

                // Phụ cấp
                var phuCaps = await _phuCapRepository.GetListAsync(x => x.ChucVuId == nv.ChucVuId);
                luong.PhuCap = phuCaps.Sum(x => x.SoTien);

                // KPI thưởng
                var kpi = await _kpiRepository.FirstOrDefaultAsync(x => x.NhanVienId == nv.Id && x.Thang == month && x.Nam == year);
                luong.ThuongKpi = kpi?.ThuongKpi ?? 0;

                // Cộng/trừ từ chế độ
                var cheDos = await _cheDoRepository.GetListAsync(x =>
                    x.NhanVienId == nv.Id &&
                    x.NgayBatDau <= today &&
                    x.NgayKetThuc >= today);
                luong.CongTruCheDo = cheDos.Sum(x => x.ThanhTien ?? 0);

                // Tổng lương
                luong.TinhTongLuong(nv.LuongCoBan);


                if (isNew)
                    await Repository.InsertAsync(luong);
                else
                    await Repository.UpdateAsync(luong);
            }
        }

        public async Task TinhLuongThangAsync(int thang, int nam)
        {
            // Tổng hợp logic tương tự, chỉ khác là tính trên toàn bộ tháng
            await TinhLuongHangNgayAsync(); // hoặc viết logic riêng chi tiết hơn
        }
    }
}
