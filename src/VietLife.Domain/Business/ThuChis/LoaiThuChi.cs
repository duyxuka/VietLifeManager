using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.PhieuNhapXuats;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.ThuChis
{
    public class LoaiThuChi : FullAuditedAggregateRoot<Guid>
    {
        public string Ten { get; set; }
        public bool IsThu { get; set; } // true = Thu, false = Chi
        public string MoTa { get; set; }
        public virtual ICollection<ThuChi> ThuChis { get; set; }
    }
}
