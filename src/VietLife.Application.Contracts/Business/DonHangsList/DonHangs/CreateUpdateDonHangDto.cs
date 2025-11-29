using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.DonHangsList.ChiTietDonHangs;

namespace VietLife.Business.DonHangsList.DonHangs
{
    public class CreateUpdateDonHangDto
    {
        public string MaDonHang { get; set; }
        public Guid BaoGiaId { get; set; }
        public Guid? KhachHangId { get; set; }
        public Guid LoaiDonHangId { get; set; }
        public string MaDonHangGoc { get; set; }
        public DateTime NgayDatHang { get; set; }
        public decimal TongTien { get; set; }
        public Guid? NhanVienBanHangId { get; set; }
        public Guid? NhanVienGiaoHangId { get; set; }
        public List<ChiTietDonHangDto> ChiTietDonHangs { get; set; }
    }
}
