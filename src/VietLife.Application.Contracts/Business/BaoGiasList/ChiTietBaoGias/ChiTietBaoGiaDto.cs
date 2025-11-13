using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.BaoGiasList.ChiTietBaoGias
{
    public class ChiTietBaoGiaDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid BaoGiaId { get; set; }
        public Guid SanPhamId { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
