using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.KhachHangsList.KhachHangs
{
    public class KhachHangInListDto : EntityDto<Guid>
    {
        public string MaKhachHang { get; set; }
        public string TenCongTy { get; set; }
        public string TenGiaoDich { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string LoaiKhachHangTen { get; set; }
        public string ThanhPhoTen { get; set; }
        public bool TrangThai { get; set; }
    }
}
