using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.DonHangs
{
    public class LoaiDonHang : FullAuditedAggregateRoot<Guid>
    {
        //[Comment("Tên loại: TikTok Shop, Shopee, Lazada, Website, Cửa hàng")]
        public string TenLoai { get; set; }
        //[Comment("Có hiệu lực không")]
        public bool HieuLuc { get; set; } = true;
        //[Comment("Tự động xuất kho khi duyệt")]
        public bool TuDongXuatKho { get; set; } = false;
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
