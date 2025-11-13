using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.SanPhams
{
    public class DonViTinh : FullAuditedAggregateRoot<Guid>
    {
        //[Comment("Tên đơn vị: Cái, Bộ, Thùng, Kg, Mét")]
        public string TenDonVi { get; set; }

        public bool MacDinh { get; set; } = false;
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
