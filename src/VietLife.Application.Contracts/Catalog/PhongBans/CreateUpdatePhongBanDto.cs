using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.PhongBans
{
    public class CreateUpdatePhongBanDto
    {
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public Guid? TruongPhongId { get; set; }
    }
}
