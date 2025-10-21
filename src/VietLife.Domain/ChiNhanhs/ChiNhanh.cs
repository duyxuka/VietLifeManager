using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.NhanViens;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.ChiNhanhs
{
    public class ChiNhanh : FullAuditedAggregateRoot<Guid>
    {
        public string TenChiNhanh { get; set; }
        public string MoTa { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
