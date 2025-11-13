using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.PhieuNhapXuats;
using VietLife.Business.ThanhPhos;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.KhoHangs
{
    public class KhoHang : FullAuditedAggregateRoot<Guid>
    {
        public string TenKho { get; set; }
        public string DiaChi { get; set; }
        public Guid? ThanhPhoId { get; set; }
        public virtual ThanhPho ThanhPho { get; set; }
        // Kho gốc
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuatsGoc { get; set; }

        // Kho đích (nếu có chuyển kho)
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuatsDen { get; set; }
    }
}
