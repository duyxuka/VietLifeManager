using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VietLife.Business.BaoGias;
using VietLife.Business.DonHangs;
using VietLife.Business.PhieuNhapXuats;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.SanPhams
{
    public class SanPham : FullAuditedAggregateRoot<Guid>
    {
        public SanPham() { }

        public SanPham(
            Guid id,
            string ten,
            string ma,
            string model,
            bool hoatDong,
            string moTa,
            string anh,
            decimal giaBan,
            Guid donViTinhId,
            Guid nhomSanPhamId)
            : base(id)
        {
            Ten = ten;
            Ma = ma;
            Model = model;
            HoatDong = hoatDong;
            MoTa = moTa;
            Anh = anh;
            GiaBan = giaBan;
            DonViTinhId = donViTinhId;
            NhomSanPhamId = nhomSanPhamId;
        }

        public string Ma { get; set; } = default!;
        public string Ten { get; set; } = default!;
        public string Model { get; set; }
        public string MoTa { get; set; }
        public string Anh { get; set; }
        public decimal GiaBan { get; set; }
        public bool HoatDong { get; set; } = true;
        public Guid NhomSanPhamId { get; set; }
        public virtual NhomSanPham NhomSanPham { get; set; }
        public Guid DonViTinhId { get; set; }
        public virtual DonViTinh DonViTinh { get; set; }

        public virtual ICollection<ChiTietPhieuNhapXuat> ChiTietPhieuNhapXuats { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual ICollection<ChiTietBaoGia> ChiTietBaoGias { get; set; }
    }
}
