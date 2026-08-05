using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.TuongTac.Insurer.BaiViets
{
    public class BaiVietDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }

        public Guid NhomId { get; set; }
        public string NhomTen { get; set; }

        public Guid? SanPhamId { get; set; }
        public string SanPhamTen { get; set; }

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

    public class BaiVietInListDto : EntityDto<Guid>
    {
        public Guid NhomId { get; set; }
        public string NhomTen { get; set; }

        public Guid? SanPhamId { get; set; }
        public string SanPhamTen { get; set; }

        public string TieuDe { get; set; }
        public string Slug { get; set; }
        public string MoTaNgan { get; set; }
        public string AnhDaiDien { get; set; }
        public DateTime XuatBanLuc { get; set; }
        public bool HienThi { get; set; }
    }

    public class CreateUpdateBaiVietDto
    {
        public Guid NhomId { get; set; }
        public Guid? SanPhamId { get; set; }

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
