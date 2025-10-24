using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.ChamCongs;
using VietLife.CheDoNhanViens;
using VietLife.ChiNhanhs;
using VietLife.Chucvus;
using VietLife.KPINhanViens;
using VietLife.LuongNhanViens;
using VietLife.PhongBans;
using VietLife.PhuCapNhanViens;
using Volo.Abp.Identity;

namespace VietLife.NhanViens
{
    public class NhanVien : IdentityUser
    {
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
        public Guid? ChiNhanhId { get; set; }
        public DateTime? NgayVaoLam { get; set; }
        public string TrangThai { get; set; }
        public decimal LuongCoBan { get; set; } // Lương cơ bản cố định, lưu ở đây vì per nhân viên
        public decimal DonGiaCong { get; set; } // Đơn giá công ngày, dùng để tính LuongTheoNgayCong
        public virtual PhongBan PhongBan { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual ChiNhanh ChiNhanh { get; set; }
        public virtual ICollection<ChamCong> ChamCongs { get; set; }
        public virtual ICollection<LuongNhanVien> LuongNhanViens { get; set; }
        public virtual ICollection<KpiNhanVien> KpiNhanViens { get; set; }
        public virtual ICollection<CheDoNhanVien> CheDoNhanViens { get; set; }

        public NhanVien(Guid id, string userName, string email)
            : base(id, userName, email)
        {
            UserName = userName;
            Email = email;
            ChamCongs = new HashSet<ChamCong>();
            LuongNhanViens = new HashSet<LuongNhanVien>();
            KpiNhanViens = new HashSet<KpiNhanVien>();
            CheDoNhanViens = new HashSet<CheDoNhanVien>();
        }

        public NhanVien() : base()
        {
            ChamCongs = new HashSet<ChamCong>();
            LuongNhanViens = new HashSet<LuongNhanVien>();
            KpiNhanViens = new HashSet<KpiNhanVien>();
            CheDoNhanViens = new HashSet<CheDoNhanVien>();
        }
    }
}
