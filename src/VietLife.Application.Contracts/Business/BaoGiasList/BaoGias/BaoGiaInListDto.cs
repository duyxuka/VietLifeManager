using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.BaoGiasList.BaoGias
{
    public class BaoGiaInListDto : EntityDto<Guid>
    {
        public string MaBaoGia { get; set; }
        public string TieuDe { get; set; }

        public Guid? KhachHangId { get; set; }

        public Guid? NhanVienId { get; set; }

        public DateTime NgayBaoGia { get; set; }
        public DateTime? NgayHetHan { get; set; }

        public decimal TongTien { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal VAT { get; set; }

        public Guid? TienTeId { get; set; }

        public bool DaChuyenDonHang { get; set; } = false;
        public string TenKhachHang { get; set; }
        public string TenNhanVien { get; set; }
    }
}
