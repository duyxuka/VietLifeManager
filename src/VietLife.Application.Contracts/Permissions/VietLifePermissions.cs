namespace VietLife.Permissions;

public static class VietLifePermissions
{
    public const string SystemGroupName = "VietLifeAdminSystem";
    public const string CatalogGroupName = "VietLifeAdminCatalog";



    //Add your own permission names. Example:
    public static class Role
    {
        public const string Default = SystemGroupName + ".Role";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class User
    {
        public const string Default = SystemGroupName + ".User";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class ChiNhanh
    {
        public const string Default = CatalogGroupName + ".ChiNhanh";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PhongBan
    {
        public const string Default = CatalogGroupName + ".PhongBan";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class ChucVu
    {
        public const string Default = CatalogGroupName + ".ChucVu";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class ChamCong
    {
        public const string Default = CatalogGroupName + ".ChamCong";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string CheckIn = Default + ".CheckIn";
        public const string CheckOut = Default + ".CheckOut";
    }

    public static class LichLamViec
    {
        public const string Default = CatalogGroupName + ".LichLamViec";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class LoaiCheDo
    {
        public const string Default = CatalogGroupName + ".LoaiCheDo";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class CheDoNhanVien
    {
        public const string Default = CatalogGroupName + ".CheDoNhanVien";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class PhuCapNhanVien
    {
        public const string Default = CatalogGroupName + ".PhuCapNhanVien";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
    public static class KpiNhanVien
    {
        public const string Default = CatalogGroupName + ".KpiNhanVien";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";

        public static class KeHoachCongViec
        {
            public const string Default = KpiNhanVien.Default + ".KeHoachCongViec";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class MucTieuKpi
        {
            public const string Default = KpiNhanVien.Default + ".MucTieuKpi";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class TienDoLamViec
        {
            public const string Default = KpiNhanVien.Default + ".TienDoLamViec";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class DanhGiaKpi
        {
            public const string Default = KpiNhanVien.Default + ".DanhGiaKpi";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }
    }

    public static class LuongNhanVien
    {
        public const string Default = CatalogGroupName + ".LuongNhanVien";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
    public static class Product
    {
        public const string Default = CatalogGroupName + ".Product";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string AttributeManage = Default + ".Attribute";
    }

    public static class Attribute
    {
        public const string Default = CatalogGroupName + ".Attribute";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }

    public static class Manufacturer
    {
        public const string Default = CatalogGroupName + ".Manufacturer";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
    public static class ProductCategory
    {
        public const string Default = CatalogGroupName + ".ProductCategory";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}
