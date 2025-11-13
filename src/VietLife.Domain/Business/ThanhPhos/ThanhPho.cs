using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.KhachHangs;
using VietLife.Business.KhoHangs;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.ThanhPhos
{
    public class ThanhPho : FullAuditedAggregateRoot<Guid>
    {
        public string Ten { get; set; }
        public string MaVung { get; set; } // VD: "HN", "HCM"
        public virtual ICollection<KhoHang> KhoHangs { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
