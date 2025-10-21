using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.KPINhanViens
{
    public class MucTieuKpi : FullAuditedAggregateRoot<Guid>
    {
        public Guid KpiNhanVienId { get; set; }
        public string TenMucTieu { get; set; }
        public decimal? GiaTriMucTieu { get; set; }  // Giá trị mục tiêu
        public string DonVi { get; set; }  // Đơn vị đo lường
        public decimal TrongSo { get; set; }  // Trọng số của mục tiêu trong KPI

        public virtual KpiNhanVien KpiNhanVien { get; set; }
    }
}
