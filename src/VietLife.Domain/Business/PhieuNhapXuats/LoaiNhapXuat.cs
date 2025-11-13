using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.PhieuNhapXuats
{
    public class LoaiNhapXuat : FullAuditedAggregateRoot<Guid>
    {
        //[Comment("Tên loại: Nhập mua, Xuất bán, Chuyển kho, Điều chỉnh")]
        public string TenLoai { get; set; }

        //[Comment("Loại: 1=Nhập, 2=Xuất, 3=Chuyển, 4=Điều chỉnh")]
        public int KieuNhapXuat { get; set; }

        public bool TangGiamTon { get; set; } // true = tăng tồn, false = giảm
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuats { get; set; }
    }
}
