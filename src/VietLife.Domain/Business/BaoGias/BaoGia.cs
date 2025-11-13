using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.KhachHangs;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using VietLife.Business.TienTes;
using VietLife.Catalog.NhanViens;
using VietLife.Business.PhieuNhapXuats;
using VietLife.Business.DonHangs;

namespace VietLife.Business.BaoGias
{
    public class BaoGia : FullAuditedAggregateRoot<Guid>
    {
        public string MaBaoGia { get; set; }
        public string TieuDe { get; set; }

        public Guid? KhachHangId { get; set; }
        public virtual KhachHang KhachHang { get; set; }

        public Guid? NhanVienId { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        public DateTime NgayBaoGia { get; set; }
        public DateTime? NgayHetHan { get; set; }

        public decimal TongTien { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal VAT { get; set; }

        public Guid? TienTeId { get; set; }
        public virtual TienTe TienTe { get; set; }

        public bool DaChuyenDonHang { get; set; } = false;

        public virtual ICollection<ChiTietBaoGia> ChiTietBaoGias { get; set; }
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuats { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
