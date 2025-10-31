using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.NhanViens;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Catalog.LuongNhanViens
{
    public class LuongNhanVien : FullAuditedAggregateRoot<Guid>
    {
        public Guid NhanVienId { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal? LuongTheoNgayCong { get; set; }  // Lương theo ngày công (từ ChamCong.CongNgay * NhanVien.DonGiaCong)
        public decimal? PhuCap { get; set; }  // Tổng phụ cấp (từ PhuCapNhanVien.SoTien)
        public decimal? ThuongKpi { get; set; }  // Thưởng KPI (từ KpiNhanVien.ThuongKpi)
        public decimal? ThuongKhac { get; set; }  // Thưởng khác (từ ChamCong: ThemGio, Thu7, ChuNhat, NgayLe)
        public decimal? KhauTru { get; set; }  // Khấu trừ (từ ChamCong: SoPhutDiMuon, SoPhutVeSom, KhongLuong)
        public decimal? CongTruCheDo { get; set; }  // Cộng/trừ từ chế độ (từ CheDoNhanVien.ThanhTien)
        public decimal? TongLuong { get; set; }  // Tổng = LuongCoBan + LuongTheoNgayCong + PhuCap + ThuongKpi + ThuongKhac + CongTruCheDo - KhauTru
        public DateTime? NgayTinhLuong { get; set; }
        public Guid? NguoiTinhLuongId { get; set; }
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public void TinhTongLuong(decimal luongCoBan)
        {
            TongLuong = luongCoBan
                      + (LuongTheoNgayCong ?? 0)
                      + (PhuCap ?? 0)
                      + (ThuongKpi ?? 0)
                      + (ThuongKhac ?? 0)
                      + (CongTruCheDo ?? 0)
                      - (KhauTru ?? 0);
        }
    }
}
