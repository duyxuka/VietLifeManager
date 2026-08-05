using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.TuongTac.Insurer.Nhoms
{
    public class NhomDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }

        public Guid DanhMucId { get; set; }
        public string DanhMucTen { get; set; }

        public string Ten { get; set; }
        public string Slug { get; set; }
        public string MoTa { get; set; }
        public string LogoUrl { get; set; }
        public int ThuTu { get; set; }
        public string SeoTitle { get; set; }          // <title> tag, ~60 ký tự
        public string SeoKeywords { get; set; }        // meta keywords
        public string SeoDescription { get; set; }
    }

    public class NhomInListDto : EntityDto<Guid>
    {
        public Guid DanhMucId { get; set; }
        public string DanhMucTen { get; set; }

        public string Ten { get; set; }
        public string Slug { get; set; }
        public string MoTa { get; set; }
        public string LogoUrl { get; set; }
        public int ThuTu { get; set; }
    }

    public class CreateUpdateNhomDto
    {
        public Guid DanhMucId { get; set; }

        public string Ten { get; set; }
        public string Slug { get; set; }
        public string LogoUrl { get; set; }
        public string MoTa { get; set; }
        public int ThuTu { get; set; }
        public string SeoTitle { get; set; }          // <title> tag, ~60 ký tự
        public string SeoKeywords { get; set; }        // meta keywords
        public string SeoDescription { get; set; }
    }
}
