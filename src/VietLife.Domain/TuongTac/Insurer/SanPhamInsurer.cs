using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.TuongTac.Insurer
{
    public class SanPhamInsurer : FullAuditedAggregateRoot<Guid>
    {
        public Guid NhomId { get; set; }
        public Nhom Nhom { get; set; }

        public string Ten { get; set; }
        public string Slug { get; set; }
        public string QuyenLoi { get; set; }
        public string BieuPhi { get; set; }
        public string TaiLieu { get; set; }
        public string KhuyenMai { get; set; }
        public string DangKy { get; set; }
        public int ThuTu { get; set; }
        public bool HienThi { get; set; }
        public string SeoTitle { get; set; }          // <title> tag, ~60 ký tự
        public string SeoKeywords { get; set; }        // meta keywords
        public string SeoDescription { get; set; }
    }
}
