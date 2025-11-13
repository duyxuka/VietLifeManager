using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.ThanhPhos;
using Volo.Abp.Domain.Entities.Auditing;
using VietLife.Business.BaoGias;
using VietLife.Business.DonHangs;
using VietLife.Business.ThuChis;

namespace VietLife.Business.KhachHangs
{
    public class KhachHang : FullAuditedAggregateRoot<Guid>
    {
        public string MaKhachHang { get; set; }
        //CÔNG TY TNHH THƯƠNG MẠI VÀ DỊCH VỤ VIETLIFE
        public string TenCongTy { get; set; }
        //VietLife Co., Ltd” hoặc “VietLife
        public string TenGiaoDich { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }

        // Danh mục
        public Guid? LoaiKhachHangId { get; set; }
        public virtual LoaiKhachHang LoaiKhachHang { get; set; }

        public Guid? ThanhPhoId { get; set; }
        public virtual ThanhPho ThanhPho { get; set; }
        public bool TrangThai { get; set; } = true;

        public virtual ICollection<BaoGia> BaoGias { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual ICollection<ThuChi> ThuChis { get; set; }
    }
}
