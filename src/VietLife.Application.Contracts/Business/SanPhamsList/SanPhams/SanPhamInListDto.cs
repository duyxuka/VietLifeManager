using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.SanPhamsList.SanPhams
{
    public class SanPhamInListDto : EntityDto<Guid>
    {
        public string Ma { get; set; } = default!;
        public string Ten { get; set; } = default!;
        public string Model { get; set; }
        public string MoTa { get; set; }
        public string Anh { get; set; }
        public decimal GiaBan { get; set; }
        public bool HoatDong { get; set; } = true;
        public Guid NhomSanPhamId { get; set; }
        public Guid DonViTinhId { get; set; }
        public string NhomSanPhamTen { get; set; }
        public string DonViTinhTen { get; set; }
    }
}
