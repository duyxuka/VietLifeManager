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
    public class TaiKhoanKeToan : FullAuditedAggregateRoot<Guid>
    {
        public string SoTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MoTa { get; set; }
        public virtual ICollection<ThuChi> ThuChisCo { get; set; }
        public virtual ICollection<ThuChi> ThuChisNo { get; set; }
    }
}
