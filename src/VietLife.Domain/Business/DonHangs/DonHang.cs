using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.BaoGias;
using VietLife.Business.KhachHangs;
using Volo.Abp.Domain.Entities.Auditing;
using VietLife.Catalog.NhanViens;
using VietLife.Business.PhieuNhapXuats;

namespace VietLife.Business.DonHangs
{
    public class DonHang : FullAuditedAggregateRoot<Guid>
    {
        public string MaDonHang { get; set; }
        public Guid BaoGiaId { get; set; }
        public virtual BaoGia BaoGia { get; set; }
        public Guid? KhachHangId { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public Guid LoaiDonHangId { get; set; }
        public virtual LoaiDonHang LoaiDonHang { get; set; }
        public string MaDonHangGoc { get; set; } // Ví dụ: 123456789_TT
        public DateTime NgayDatHang { get; set; }
        public decimal TongTien { get; set; }

        //[Comment("Nhân viên bán hàng - từ HRM")]
        public Guid? NhanVienBanHangId { get; set; }
        public virtual NhanVien NhanVienBanHang { get; set; }

        //[Comment("Nhân viên giao hàng")]
        public Guid? NhanVienGiaoHangId { get; set; }
        public virtual NhanVien NhanVienGiaoHang { get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuats { get; set; }
    }
}
