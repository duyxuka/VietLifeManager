using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Catalog.CheDoNhanViens
{
    public class LoaiCheDo : FullAuditedAggregateRoot<Guid>
    {
        public string TenLoaiCheDo { get; set; }
        public decimal HeSoCong { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<CheDoNhanVien> CheDoNhanViens { get; set; }

        public LoaiCheDo()
        {
            CheDoNhanViens = new HashSet<CheDoNhanVien>();
        }
    }
}
