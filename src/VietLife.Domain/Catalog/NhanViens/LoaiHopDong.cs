using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Catalog.NhanViens
{
    public class LoaiHopDong : FullAuditedAggregateRoot<Guid>
    {
        public string TenLoai { get; set; } // Chính thức, Thử việc, Thời vụ

        public int? SoThangMacDinh { get; set; }

        public bool MacDinh { get; set; } = false;
        public virtual ICollection<HopDongNhanVien> HopDongNhanViens { get; set; }
    }
}
