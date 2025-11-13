using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.SanPhams
{
    public class NhomSanPham : FullAuditedAggregateRoot<Guid>
    {
        //[Comment("Tên nhóm: Điện tử, Văn phòng, Dịch vụ...")]
        public string TenNhom { get; set; }
        public string MaNhom { get; set; }
        public bool HieuLuc { get; set; } = true;
        public virtual ICollection<SanPham> SanPhams { get; set; }
        public NhomSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }
    }
}
