using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.NhapXuats.ChiTietPhieuNhapXuats;

namespace VietLife.Business.NhapXuats.PhieuNhapXuats
{
    public class CreateUpdatePhieuNhapXuatDto
    {
        public string MaPhieu { get; set; }
        public Guid LoaiNhapXuatId { get; set; }
        public Guid? KhoId { get; set; }
        public Guid? KhoDenId { get; set; }
        public Guid? DonHangId { get; set; }
        public Guid? BaoGiaId { get; set; }
        public Guid? NhanVienLapId { get; set; }
        public DateTime NgayLap { get; set; } = DateTime.Now;
        public List<CreateUpdateChiTietPhieuNhapXuatDto> ChiTietPhieuNhapXuats { get; set; }
    }
}
