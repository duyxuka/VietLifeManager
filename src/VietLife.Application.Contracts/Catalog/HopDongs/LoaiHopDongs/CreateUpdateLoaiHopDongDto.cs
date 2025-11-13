using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.HopDongs.LoaiHopDongs
{
    public class CreateUpdateLoaiHopDongDto
    {
        public string TenLoai { get; set; }
        public int? SoThangMacDinh { get; set; }
        public bool MacDinh { get; set; }
    }
}
