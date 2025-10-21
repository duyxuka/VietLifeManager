using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.PhuCapNhanViens
{
    public class CreateUpdatePhuCapNhanVienDto
    {
        public Guid ChucVuId { get; set; }
        public string TenPhuCap { get; set; }
        public decimal SoTien { get; set; }
    }
}
