namespace VietLife.Permissions;

public static class VietLifePermissions
{
    public const string SystemGroupName = "VietLifeAdminSystem";
    public const string CatalogGroupName = "VietLifeAdminCatalog";
    public const string BusinessGroupName = "VietLifeAdminBusiness";



    //Add your own permission names. Example:
    public static class Role
    {
        public const string Default = SystemGroupName + ".Role";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class User
    {
        public const string Default = SystemGroupName + ".User";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class ChiNhanh
    {
        public const string Default = CatalogGroupName + ".ChiNhanh";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PhongBan
    {
        public const string Default = CatalogGroupName + ".PhongBan";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class ChucVu
    {
        public const string Default = CatalogGroupName + ".ChucVu";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class ChamCong
    {
        public const string Default = CatalogGroupName + ".ChamCong";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string CheckIn = Default + ".CheckIn";
        public const string CheckOut = Default + ".CheckOut";
    }

    public static class LichLamViec
    {
        public const string Default = CatalogGroupName + ".LichLamViec";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class LoaiCheDo
    {
        public const string Default = CatalogGroupName + ".LoaiCheDo";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class CheDoNhanVien
    {
        public const string Default = CatalogGroupName + ".CheDoNhanVien";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Approve = Default + ".Approve";
    }

    public static class PhuCapNhanVien
    {
        public const string Default = CatalogGroupName + ".PhuCapNhanVien";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
    public static class KpiNhanVien
    {
        public const string Default = CatalogGroupName + ".KpiNhanVien";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";

        public static class KeHoachCongViec
        {
            public const string Default = KpiNhanVien.Default + ".KeHoachCongViec";
            public const string View = Default + ".View";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class MucTieuKpi
        {
            public const string Default = KpiNhanVien.Default + ".MucTieuKpi";
            public const string View = Default + ".View";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class TienDoLamViec
        {
            public const string Default = KpiNhanVien.Default + ".TienDoLamViec";
            public const string View = Default + ".View";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class DanhGiaKpi
        {
            public const string Default = KpiNhanVien.Default + ".DanhGiaKpi";
            public const string View = Default + ".View";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
    }

    public static class LuongNhanVien
    {
        public const string Default = CatalogGroupName + ".LuongNhanVien";
        public const string ViewAll = Default + ".ViewAll";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
    // === LO?I H?P ??NG ===
    public static class LoaiHopDong
    {
        public const string Default = CatalogGroupName + ".LoaiHopDong";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    // === H?P ??NG NHÂN VIÊN ===
    public static class HopDongNhanVien
    {
        public const string Default = CatalogGroupName + ".HopDongNhanVien";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string Approve = Default + ".Approve"; // n?u c?n duy?t h?p ??ng
    }

    //Business
    public static class NhomSanPham
    {
        public const string Default = BusinessGroupName + ".NhomSanPham";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class DonViTinh
    {
        public const string Default = BusinessGroupName + ".DonViTinh";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class SanPham
    {
        public const string Default = BusinessGroupName + ".SanPham";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class KhoHang
    {
        public const string Default = BusinessGroupName + ".KhoHang";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class ThanhPho
    {
        public const string Default = BusinessGroupName + ".ThanhPho";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class TienTe
    {
        public const string Default = BusinessGroupName + ".TienTe";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class LoaiKhachHang
    {
        public const string Default = BusinessGroupName + ".LoaiKhachHang";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class KhachHang
    {
        public const string Default = BusinessGroupName + ".KhachHang";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
    public static class LoaiThuChi
    {
        public const string Default = BusinessGroupName + ".LoaiThuChi";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class TaiKhoanKeToan
    {
        public const string Default = BusinessGroupName + ".TaiKhoanKeToan";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class ThuChi
    {
        public const string Default = BusinessGroupName + ".ThuChi";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class BaoGia
    {
        public const string Default = BusinessGroupName + ".BaoGia";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class  LoaiDonHang
    {
        public const string Default = BusinessGroupName + ".LoaiDonHang";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class DonHang
    {
        public const string Default = BusinessGroupName + ".DonHang";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class LoaiNhapXuat
    {
        public const string Default = BusinessGroupName + ".LoaiNhapXuat";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PhieuNhapXuat
    {
        public const string Default = BusinessGroupName + ".PhieuNhapXuat";
        public const string View = Default + ".View";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}
