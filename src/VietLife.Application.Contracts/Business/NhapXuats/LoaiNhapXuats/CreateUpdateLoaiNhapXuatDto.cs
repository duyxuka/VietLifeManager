using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.NhapXuats.LoaiNhapXuats
{
    public class CreateUpdateLoaiNhapXuatDto
    {
        public string TenLoai { get; set; }
        public int KieuNhapXuat { get; set; }
        public bool TangGiamTon { get; set; }
    }
}
