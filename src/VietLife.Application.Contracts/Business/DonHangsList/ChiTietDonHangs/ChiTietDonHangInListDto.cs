using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.DonHangsList.ChiTietDonHangs
{
    public class ChiTietDonHangInListDto : EntityDto<Guid>
    {
        public Guid DonHangId { get; set; }
        public Guid SanPhamId { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ChietKhau { get; set; }
        public decimal VAT { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
