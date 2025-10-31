using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.NhanViens;
using VietLife.Catalog.PhuCapNhanViens;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Catalog.Chucvus
{
    public class ChucVu : FullAuditedAggregateRoot<Guid>
    {
        public string TenChucVu { get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual ICollection<PhuCapNhanVien> PhuCapNhanViens { get; set; }
    }
}
