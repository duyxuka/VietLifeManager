using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.SanPhams;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.DonHangs
{
    public class ChiTietDonHang : FullAuditedAggregateRoot<Guid>
    {
        public Guid DonHangId { get; set; }
        public virtual DonHang DonHang { get; set; }
        public Guid SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ChietKhau { get; set; } // %
        public decimal VAT { get; set; } // %

        //[Comment("Thành tiền = SL * ĐG * (1 - CK) * (1 + VAT)")]
        public decimal ThanhTien => SoLuong * DonGia * (1 - ChietKhau / 100) * (1 + VAT / 100);
    }
}
