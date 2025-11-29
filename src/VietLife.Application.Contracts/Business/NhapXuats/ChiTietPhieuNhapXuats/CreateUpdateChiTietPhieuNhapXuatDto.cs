using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.NhapXuats.ChiTietPhieuNhapXuats
{
    public class CreateUpdateChiTietPhieuNhapXuatDto
    {
        public Guid Id { get; set; }
        public Guid PhieuNhapXuatId { get; set; }
        public Guid SanPhamId { get; set; }

        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal VAT { get; set; }
        public decimal GiaVon { get; set; }
    }
}
