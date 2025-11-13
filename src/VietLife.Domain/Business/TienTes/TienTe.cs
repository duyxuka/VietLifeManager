using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.BaoGias;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.TienTes
{
    public class TienTe : FullAuditedAggregateRoot<Guid>
    {
        //[Comment("Tên tiền tệ: VND, USD, EUR")]
        public string TenTienTe { get; set; }

        //[Comment("Mã ISO: VND, USD")]
        public string MaTienTe { get; set; }

        //[Comment("Tỷ giá so với VND")]
        public decimal TyGia { get; set; } = 1;

        public bool MacDinh { get; set; } = false;
        public virtual ICollection<BaoGia> BaoGias { get; set; }
    }
}
