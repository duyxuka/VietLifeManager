using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.TuongTac.LienHes
{
    public class LienHe : FullAuditedAggregateRoot<Guid>
    {
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TuVan { get; set; }
        public bool TrangThai { get; set; }
    }
}
