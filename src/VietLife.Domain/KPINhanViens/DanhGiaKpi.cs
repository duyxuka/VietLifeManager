using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.KPINhanViens
{
    public class DanhGiaKpi : FullAuditedAggregateRoot<Guid>
    {
        public Guid KpiNhanVienId { get; set; }
        public decimal? DiemDanhGia { get; set; }
        public string NhanXet { get; set; }
        public Guid? NguoiDanhGiaId { get; set; }

        public virtual KpiNhanVien KpiNhanVien { get; set; }
    }
}
