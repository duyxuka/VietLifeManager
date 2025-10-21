using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.CheDos.CheDoNhanViens
{
    public class CreateUpdateCheDoNhanVienDto
    {
        public Guid NhanVienId { get; set; }
        public Guid LoaiCheDoId { get; set; }
        public bool TrangThai { get; set; }
        public Guid? NguoiDuyetId { get; set; }
        public Guid? PhongBanId { get; set; }
        public Guid? ChiNhanhId { get; set; }
        public decimal? SoNgay { get; set; }
        public decimal? SoCong { get; set; }
        public decimal? ThanhTien { get; set; }
        public string LyDo { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string GhiChu { get; set; }
    }
}
