using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.BaoGias;
using VietLife.Business.DonHangs;
using VietLife.Business.PhieuNhapXuats;
using VietLife.Business.ThuChis;
using VietLife.Catalog.ChamCongs;
using VietLife.Catalog.CheDoNhanViens;
using VietLife.Catalog.ChiNhanhs;
using VietLife.Catalog.Chucvus;
using VietLife.Catalog.KPINhanViens;
using VietLife.Catalog.LuongNhanViens;
using VietLife.Catalog.PhongBans;
using Volo.Abp.Identity;

namespace VietLife.Catalog.NhanViens
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
        public virtual PhongBan PhongBan { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual ChiNhanh ChiNhanh { get; set; }
        public virtual ICollection<ChamCong> ChamCongs { get; set; }
        public virtual ICollection<LuongNhanVien> LuongNhanViens { get; set; }
        public virtual ICollection<KpiNhanVien> KpiNhanViens { get; set; }
        public virtual ICollection<CheDoNhanVien> CheDoNhanViens { get; set; }
        public virtual ICollection<HopDongNhanVien> HopDongNhanViens { get; set; }
        public virtual ICollection<PhieuNhapXuat> PhieuNhapXuats { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual ICollection<BaoGia> BaoGias { get; set; }
        public virtual ICollection<ThuChi> ThuChis { get; set; }

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
