using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.SanPhamsList.DonViTinhs
{
    public class CreateUpdateDonViTinhDto
    {
        public string TenDonVi { get; set; }
        public bool MacDinh { get; set; } = false;
    }
}
