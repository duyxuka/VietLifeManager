using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.TuongTac.Insurer
{
    public class DanhMuc : FullAuditedAggregateRoot<Guid>
    {
        public string Ten { get; set; }
        public string Slug { get; set; }
        public string MoTa { get; set; }
        public string AnhMenu { get; set; }
        public int ThuTu { get; set; }

        public ICollection<Nhom> Nhoms { get; set; }
    }
}
