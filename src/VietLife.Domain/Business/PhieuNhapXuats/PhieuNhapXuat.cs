using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.DonHangs;
using VietLife.Business.KhoHangs;
using Volo.Abp.Domain.Entities.Auditing;
using VietLife.Catalog.NhanViens;
using VietLife.Business.BaoGias;

namespace VietLife.Business.PhieuNhapXuats
{
    public class PhieuNhapXuat : FullAuditedAggregateRoot<Guid>
    {
        public string MaPhieu { get; set; }
        public Guid LoaiNhapXuatId { get; set; } // Nhập, Xuất, Chuyển
        public virtual LoaiNhapXuat LoaiNhapXuat { get; set; }

        public Guid? KhoId { get; set; }
        public virtual KhoHang KhoHang { get; set; }

        public Guid? DonHangId { get; set; }
        public virtual DonHang DonHang { get; set; }
        public Guid? BaoGiaId { get; set; }
        public virtual BaoGia BaoGia { get; set; }
        public Guid? KhoDenId { get; set; } // Chuyển kho
        public virtual KhoHang KhoDen { get; set; }

        public Guid? NhanVienLapId { get; set; }
        public virtual NhanVien NhanVienLap { get; set; }
        public DateTime NgayLap { get; set; } = DateTime.Now;
        public virtual ICollection<ChiTietPhieuNhapXuat> ChiTietPhieuNhapXuats { get; set; }
    }
}
