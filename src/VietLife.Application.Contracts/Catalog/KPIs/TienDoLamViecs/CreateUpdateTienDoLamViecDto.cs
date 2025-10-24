using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.KPIs.TienDoLamViecs
{
    public class CreateUpdateTienDoLamViecDto
    {
        public Guid KpiNhanVienId { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public decimal? PhanTramTienDo { get; set; }
        public string GhiChu { get; set; }
    }
}
