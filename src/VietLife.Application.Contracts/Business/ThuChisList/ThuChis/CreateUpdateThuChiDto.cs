using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.ThuChis;

namespace VietLife.Business.ThuChisList.ThuChis
{
    public class CreateUpdateThuChiDto
    {
        public string MaPhieu { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public DateTime NgayHachToan { get; set; }
        public string DienGiai { get; set; }

        public decimal SoTien { get; set; }

        public Guid? LoaiThuChiId { get; set; }
        public Guid? TaiKhoanNoId { get; set; }
        public Guid? TaiKhoanCoId { get; set; }

        public Guid? DoiTuongId { get; set; }
        public DoiTuongType? LoaiDoiTuong { get; set; }

        public PaymentMethod PhuongThucThanhToan { get; set; }
        public string SoTaiKhoanNganHang { get; set; }
        public string TenNganHang { get; set; }

        public string SoHoaDon { get; set; }
        public DateTime? NgayHoaDon { get; set; }
        public decimal? ThueSuat { get; set; }
        public decimal? TienThue { get; set; }
        public decimal? ThanhTienSauThue { get; set; }
    }
}
