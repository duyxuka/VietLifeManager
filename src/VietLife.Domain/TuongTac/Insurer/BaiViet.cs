using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.TuongTac.Insurer
{
    public class BaiViet : FullAuditedAggregateRoot<Guid>
    {
        public Guid NhomId { get; set; }
        public Nhom Nhom { get; set; }

        public Guid? SanPhamId { get; set; }
        public SanPhamInsurer SanPham { get; set; }

        public string TieuDe { get; set; }
        public string Slug { get; set; }
        public string MoTaNgan { get; set; }
        public string NoiDung { get; set; }
        public string AnhDaiDien { get; set; }
        public DateTime XuatBanLuc { get; set; }
        public bool HienThi { get; set; }

        public string SeoTitle { get; set; }          // <title> tag, ~60 ký tự
        public string SeoKeywords { get; set; }        // meta keywords
        public string SeoDescription { get; set; }
    }
}
