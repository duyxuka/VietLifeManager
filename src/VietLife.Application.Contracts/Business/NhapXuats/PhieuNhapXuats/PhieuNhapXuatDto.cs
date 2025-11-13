using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.NhapXuats.ChiTietPhieuNhapXuats;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.NhapXuats.PhieuNhapXuats
{
    public class PhieuNhapXuatDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string MaPhieu { get; set; }

        public Guid LoaiNhapXuatId { get; set; }
        public string LoaiNhapXuatTen { get; set; }

        public Guid? KhoId { get; set; }
        public string KhoTen { get; set; }

        public Guid? KhoDenId { get; set; }
        public string KhoDenTen { get; set; }

        public Guid? DonHangId { get; set; }
        public string MaDonHang { get; set; }

        public Guid? BaoGiaId { get; set; }
        public string MaBaoGia { get; set; }

        public Guid? NhanVienLapId { get; set; }
        public string TenNhanVienLap { get; set; }

        public DateTime NgayLap { get; set; }

        public List<ChiTietPhieuNhapXuatInListDto> ChiTietPhieuNhapXuats { get; set; }
    }
}
