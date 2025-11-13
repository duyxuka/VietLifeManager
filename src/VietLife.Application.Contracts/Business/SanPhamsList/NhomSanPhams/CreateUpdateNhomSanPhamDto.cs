using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.SanPhamsList.NhomSanPhams
{
    public class CreateUpdateNhomSanPhamDto
    {
        public string TenNhom { get; set; }
        public string MaNhom { get; set; }
        public bool HieuLuc { get; set; } = true;
    }
}
