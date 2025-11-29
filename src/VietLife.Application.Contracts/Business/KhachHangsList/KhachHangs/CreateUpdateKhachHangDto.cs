using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.KhachHangsList.KhachHangs
{
    public class CreateUpdateKhachHangDto
    {
        public string MaKhachHang { get; set; }
        public string TenCongTy { get; set; }
        public string TenKhachHang { get; set; }
        public string TenGiaoDich { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public Guid? LoaiKhachHangId { get; set; }
        public Guid? ThanhPhoId { get; set; }
        public bool TrangThai { get; set; } = true;
    }
}
