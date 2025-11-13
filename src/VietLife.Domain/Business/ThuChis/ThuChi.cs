using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.KhachHangs;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Business.ThuChis
{
    public class ThuChi : FullAuditedAggregateRoot<Guid>
    {
        public string MaPhieu { get; set; }

        public bool LaThu { get; set; } // true = thu, false = chi

        public Guid? KhachHangId { get; set; }
        public virtual KhachHang KhachHang { get; set; }

        public decimal SoTien { get; set; }
        public DateTime NgayGiaoDich { get; set; }

        public int? TaiKhoanNoId { get; set; }
        public int? TaiKhoanCoId { get; set; }
    }
}
