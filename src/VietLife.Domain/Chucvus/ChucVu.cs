using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.NhanViens;
using VietLife.PhuCapNhanViens;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Chucvus
{
    public class ChucVu : FullAuditedAggregateRoot<Guid>
    {
        public string TenChucVu { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual ICollection<PhuCapNhanVien> PhuCapNhanViens { get; set; }
    }
}
