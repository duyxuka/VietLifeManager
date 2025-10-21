using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Chucvus;
using VietLife.NhanViens;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.PhuCapNhanViens
{
    public class PhuCapNhanVien : FullAuditedEntity<Guid>
    {
        public Guid ChucVuId { get; set; }             
        public string TenPhuCap { get; set; }            
        public decimal SoTien { get; set; }                              
        public virtual ChucVu ChucVu { get; set; }
    }
}
