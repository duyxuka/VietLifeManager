using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.KPIs.TienDoLamViecs
{
    public class TienDoLamViecInListDto : EntityDto<Guid>
    {
        public Guid KpiNhanVienId { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public decimal? PhanTramTienDo { get; set; }
        public string GhiChu { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKpi { get; set; }
    }
}
