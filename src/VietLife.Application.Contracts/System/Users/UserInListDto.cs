using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.System.Users
{
    public class UserInListDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string MaNv { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string SoCmnd { get; set; }
        public DateTime? NgayCapCmnd { get; set; }
        public string NoiCapCmnd { get; set; }
        public string DiaChi { get; set; }
        public Guid? PhongBanId { get; set; }
        public Guid? ChucVuId { get; set; }
        public DateTime? NgayVaoLam { get; set; }
        public string TrangThai { get; set; }
        public decimal LuongCoBan { get; set; } // Lương cơ bản cố định, lưu ở đây vì per nhân viên
        public decimal DonGiaCong { get; set; } // Đơn giá công ngày, dùng để tính LuongTheoNgayCong
    }
}
