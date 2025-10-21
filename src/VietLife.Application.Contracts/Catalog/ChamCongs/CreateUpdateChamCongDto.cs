using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.ChamCongs
{
    public class CreateUpdateChamCongDto
    {
        public Guid NhanVienId { get; set; }
        public DateTime NgayLam { get; set; }
        public DateTime? GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public decimal? SoGioLam { get; set; }
        public decimal? SoPhutDiMuon { get; set; }
        public decimal? SoPhutVeSom { get; set; }
        public decimal? CongNgay { get; set; }
        public bool TrangThai { get; set; }
    }
}
