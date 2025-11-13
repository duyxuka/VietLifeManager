using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.SanPhams;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.BaoGias
{
    public class ChiTietBaoGia : FullAuditedAggregateRoot<Guid>
    {
        public Guid BaoGiaId { get; set; }
        public virtual BaoGia BaoGia { get; set; }

        public Guid SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }

        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal ThanhTien => SoLuong * DonGia * (1 - ChietKhau / 100);
    }
}
