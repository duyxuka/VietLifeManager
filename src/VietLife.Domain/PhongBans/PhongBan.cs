using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.NhanViens;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.PhongBans
{
    public class PhongBan : FullAuditedAggregateRoot<Guid>
    {
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public Guid? TruongPhongId { get; set; }

        // Navigation
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
