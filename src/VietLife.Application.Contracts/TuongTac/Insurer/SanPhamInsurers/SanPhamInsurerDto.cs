using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.TuongTac.Insurer.SanPhamInsurers
{
    public class SanPhamInsurerDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }

        public Guid NhomId { get; set; }
        public string NhomTen { get; set; }

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

    public class SanPhamInsurerInListDto : EntityDto<Guid>
    {
        public Guid NhomId { get; set; }
        public string NhomTen { get; set; }
        public string Slug { get; set; }

        public string Ten { get; set; }
        public string QuyenLoi { get; set; }
        public string BieuPhi { get; set; }
        public string TaiLieu { get; set; }
        public string KhuyenMai { get; set; }
        public string DangKy { get; set; }
        public int ThuTu { get; set; }
        public bool HienThi { get; set; }
    }

    public class CreateUpdateSanPhamInsurerDto
    {
        public Guid NhomId { get; set; }

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
