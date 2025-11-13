using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.KhachHangs
{
    public class LoaiKhachHang : FullAuditedAggregateRoot<Guid>
    {
        //[Comment("Tên loại khách hàng: VIP, Thường, Đối tác")]
        public string Ten { get; set; }

        //[Comment("Mô tả chi tiết")]
        public string MoTa { get; set; }

        //[Comment("Có hiệu lực không")]
        public bool HieuLuc { get; set; } = true;
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
