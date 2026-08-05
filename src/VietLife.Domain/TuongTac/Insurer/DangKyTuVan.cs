using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.TuongTac.Insurer
{
    public class DangKyTuVan : FullAuditedAggregateRoot<Guid>
    {
        public Guid? SanPhamId { get; set; }
        public SanPhamInsurer SanPham { get; set; }

        public Guid? NhomId { get; set; }
        public Nhom Nhom { get; set; }

        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
    }
}
