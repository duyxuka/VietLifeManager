using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.ThuChis;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.ThuChisList.ThuChis
{
    public class ThuChiInListDto : EntityDto<Guid>
    {
        public string MaPhieu { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public DateTime NgayHachToan { get; set; }
        public string DienGiai { get; set; }

        // 2. Số tiền
        public decimal SoTien { get; set; }

        // 3. Loại Thu/Chi
        public Guid? LoaiThuChiId { get; set; }

        // 4. Tài khoản kế toán (No/Có)
        public Guid? TaiKhoanNoId { get; set; }

        public Guid? TaiKhoanCoId { get; set; }

        // 5. Đối tượng liên quan
        public Guid? DoiTuongId { get; set; }
        public DoiTuongType? LoaiDoiTuong { get; set; }

        // 6. Thanh toán & ngân hàng
        public PaymentMethod PhuongThucThanhToan { get; set; }
        public string SoTaiKhoanNganHang { get; set; }
        public string TenNganHang { get; set; }

        // 7. Hóa đơn VAT
        public string SoHoaDon { get; set; }
        public DateTime? NgayHoaDon { get; set; }
        public decimal? ThueSuat { get; set; }
        public decimal? TienThue { get; set; }
        public decimal? ThanhTienSauThue { get; set; }

        // 8. Duyệt chứng từ
        public ThuChiStatus Status { get; set; }
        public Guid? NguoiDuyetId { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public string LyDoHuy { get; set; }
        public string TenLoaiThuChi { get; set; }
        public string TenTaiKhoanNo { get; set; }
        public string TenTaiKhoanCo { get; set; }
        public string TenNguoiDuyet { get; set; }
    }
}
