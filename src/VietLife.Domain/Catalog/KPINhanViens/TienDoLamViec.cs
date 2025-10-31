using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Catalog.KPINhanViens
{
    public class TienDoLamViec : FullAuditedAggregateRoot<Guid>
    {
        public Guid KpiNhanVienId { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public decimal? PhanTramTienDo { get; set; }
        public string GhiChu { get; set; }

        public virtual KpiNhanVien KpiNhanVien { get; set; }
    }
}
