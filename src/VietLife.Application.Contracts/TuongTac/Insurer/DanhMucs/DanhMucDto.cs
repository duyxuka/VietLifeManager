using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.TuongTac.Insurer.DanhMucs
{
    public class DanhMucDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public string Slug { get; set; }
        public string MoTa { get; set; }
        public string AnhMenu { get; set; }
        public int ThuTu { get; set; }
    }

    public class DanhMucInListDto : EntityDto<Guid>
    {
        public string Ten { get; set; }
        public string Slug { get; set; }
        public string MoTa { get; set; }
        public string AnhMenu { get; set; }
        public int ThuTu { get; set; }
    }

    public class CreateUpdateDanhMucDto
    {
        public string Ten { get; set; }
        public string Slug { get; set; }
        public string MoTa { get; set; }
        public string AnhMenu { get; set; }
        public int ThuTu { get; set; }
    }

    // MenuDto.cs
    public class SanPhamMenuDto
    {
        public string Ten { get; set; }
        public string Slug { get; set; }
    }

    public class NhomMenuDto
    {
        public string Ten { get; set; }
        public string Slug { get; set; }
        public List<SanPhamMenuDto> SanPhams { get; set; }
    }

    public class DanhMucMenuDto
    {
        public string Ten { get; set; }
        public string Slug { get; set; }
        public string MoTa { get; set; }
        public string AnhMenu { get; set; }
        public List<NhomMenuDto> Nhoms { get; set; }
    }
}
