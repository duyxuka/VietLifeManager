using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.TuongTac.Insurer
{
    public class Nhom : FullAuditedAggregateRoot<Guid>
    {
        public Guid DanhMucId { get; set; }
        public DanhMuc DanhMuc { get; set; }

        public string Ten { get; set; }
        public string Slug { get; set; }
        public string MoTa { get; set; }
        public string LogoUrl { get; set; }
        public int ThuTu { get; set; }
        public string SeoTitle { get; set; }          // <title> tag, ~60 ký tự
        public string SeoKeywords { get; set; }        // meta keywords
        public string SeoDescription { get; set; }
        public ICollection<BaiViet> BaiViets { get; set; }

        public ICollection<SanPhamInsurer> SanPhams { get; set; }
    }
}
