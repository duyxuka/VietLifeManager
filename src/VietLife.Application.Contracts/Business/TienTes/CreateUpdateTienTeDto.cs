using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.TienTes
{
    public class CreateUpdateTienTeDto
    {
        public string TenTienTe { get; set; }
        public string MaTienTe { get; set; }
        public decimal TyGia { get; set; } = 1;
        public bool MacDinh { get; set; } = false;
    }
}
