using VietLife.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace VietLife.Permissions;

public class VietLifePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //System
        var identityGroup = context.GetGroupOrNull("AbpIdentity")
        ?? context.AddGroup("AbpIdentity", L("Permission:IdentityManagement"));

        var userPermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Users.Default)
            ?? identityGroup.AddPermission(IdentityPermissions.Users.Default, L("Permission:Identity.Users"));

        userPermission.AddChild(ExtendedIdentityPermissions.Users.View, L("Permission:Identity.Users.View"));

        var rolePermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Roles.Default)
            ?? identityGroup.AddPermission(IdentityPermissions.Roles.Default, L("Permission:Identity.Roles"));

        rolePermission.AddChild(ExtendedIdentityPermissions.Roles.View, L("Permission:Identity.Roles.View"));


        //Catalog
        var catalogGroup = context.AddGroup(VietLifePermissions.CatalogGroupName, L("Permission:Catalog"));

        // === CHI NHÁNH ===
        var chiNhanhPermission = catalogGroup.AddPermission(VietLifePermissions.ChiNhanh.Default, L("Permission:Catalog.ChiNhanh"));
        chiNhanhPermission.AddChild(VietLifePermissions.ChiNhanh.View, L("Permission:Catalog.ChiNhanh.View"));
        chiNhanhPermission.AddChild(VietLifePermissions.ChiNhanh.Create, L("Permission:Catalog.ChiNhanh.Create"));
        chiNhanhPermission.AddChild(VietLifePermissions.ChiNhanh.Update, L("Permission:Catalog.ChiNhanh.Update"));
        chiNhanhPermission.AddChild(VietLifePermissions.ChiNhanh.Delete, L("Permission:Catalog.ChiNhanh.Delete"));

        // === PHÒNG BAN ===
        var phongBanPermission = catalogGroup.AddPermission(VietLifePermissions.PhongBan.Default, L("Permission:Catalog.PhongBan"));
        phongBanPermission.AddChild(VietLifePermissions.PhongBan.View, L("Permission:Catalog.PhongBan.View"));
        phongBanPermission.AddChild(VietLifePermissions.PhongBan.Create, L("Permission:Catalog.PhongBan.Create"));
        phongBanPermission.AddChild(VietLifePermissions.PhongBan.Update, L("Permission:Catalog.PhongBan.Update"));
        phongBanPermission.AddChild(VietLifePermissions.PhongBan.Delete, L("Permission:Catalog.PhongBan.Delete"));

        // === CH?C V? ===
        var chucVuPermission = catalogGroup.AddPermission(VietLifePermissions.ChucVu.Default, L("Permission:Catalog.ChucVu"));
        chucVuPermission.AddChild(VietLifePermissions.ChucVu.View, L("Permission:Catalog.ChucVu.View"));
        chucVuPermission.AddChild(VietLifePermissions.ChucVu.Create, L("Permission:Catalog.ChucVu.Create"));
        chucVuPermission.AddChild(VietLifePermissions.ChucVu.Update, L("Permission:Catalog.ChucVu.Update"));
        chucVuPermission.AddChild(VietLifePermissions.ChucVu.Delete, L("Permission:Catalog.ChucVu.Delete"));

        // === CH?M CÔNG ===
        var chamCongPermission = catalogGroup.AddPermission(VietLifePermissions.ChamCong.Default, L("Permission:Catalog.ChamCong"));
        chamCongPermission.AddChild(VietLifePermissions.ChamCong.View, L("Permission:Catalog.ChamCong.View"));
        chamCongPermission.AddChild(VietLifePermissions.ChamCong.Create, L("Permission:Catalog.ChamCong.Create"));
        chamCongPermission.AddChild(VietLifePermissions.ChamCong.Update, L("Permission:Catalog.ChamCong.Update"));
        chamCongPermission.AddChild(VietLifePermissions.ChamCong.Delete, L("Permission:Catalog.ChamCong.Delete"));
        chamCongPermission.AddChild(VietLifePermissions.ChamCong.CheckIn, L("Permission:Catalog.ChamCong.CheckIn"));
        chamCongPermission.AddChild(VietLifePermissions.ChamCong.CheckOut, L("Permission:Catalog.ChamCong.CheckOut"));

        // === L?CH LÀM VI?C ===
        var lichLamViecPermission = catalogGroup.AddPermission(VietLifePermissions.LichLamViec.Default, L("Permission:Catalog.LichLamViec"));
        lichLamViecPermission.AddChild(VietLifePermissions.LichLamViec.View, L("Permission:Catalog.LichLamViec.View"));
        lichLamViecPermission.AddChild(VietLifePermissions.LichLamViec.Create, L("Permission:Catalog.LichLamViec.Create"));
        lichLamViecPermission.AddChild(VietLifePermissions.LichLamViec.Update, L("Permission:Catalog.LichLamViec.Update"));
        lichLamViecPermission.AddChild(VietLifePermissions.LichLamViec.Delete, L("Permission:Catalog.LichLamViec.Delete"));

        // === LO?I CH? ?? ===
        var loaiCheDoPermission = catalogGroup.AddPermission(VietLifePermissions.LoaiCheDo.Default, L("Permission:Catalog.LoaiCheDo"));
        loaiCheDoPermission.AddChild(VietLifePermissions.LoaiCheDo.View, L("Permission:Catalog.LoaiCheDo.View"));
        loaiCheDoPermission.AddChild(VietLifePermissions.LoaiCheDo.Create, L("Permission:Catalog.LoaiCheDo.Create"));
        loaiCheDoPermission.AddChild(VietLifePermissions.LoaiCheDo.Update, L("Permission:Catalog.LoaiCheDo.Update"));
        loaiCheDoPermission.AddChild(VietLifePermissions.LoaiCheDo.Delete, L("Permission:Catalog.LoaiCheDo.Delete"));

        // === CH? ?? NHÂN VIÊN ===
        var cheDoNhanVienPermission = catalogGroup.AddPermission(VietLifePermissions.CheDoNhanVien.Default, L("Permission:Catalog.CheDoNhanVien"));
        cheDoNhanVienPermission.AddChild(VietLifePermissions.CheDoNhanVien.View, L("Permission:Catalog.CheDoNhanVien.View"));
        cheDoNhanVienPermission.AddChild(VietLifePermissions.CheDoNhanVien.Create, L("Permission:Catalog.CheDoNhanVien.Create"));
        cheDoNhanVienPermission.AddChild(VietLifePermissions.CheDoNhanVien.Update, L("Permission:Catalog.CheDoNhanVien.Update"));
        cheDoNhanVienPermission.AddChild(VietLifePermissions.CheDoNhanVien.Delete, L("Permission:Catalog.CheDoNhanVien.Delete"));
        cheDoNhanVienPermission.AddChild(VietLifePermissions.CheDoNhanVien.Approve, L("Permission:Catalog.CheDoNhanVien.Approve"));

        // === KPI NHÂN VIÊN ===
        var kpiPermission = catalogGroup.AddPermission(VietLifePermissions.KpiNhanVien.Default,L("Permission:Catalog.KpiNhanVien"));
        kpiPermission.AddChild(VietLifePermissions.KpiNhanVien.View, L("Permission:Catalog.KpiNhanVien.View"));
        kpiPermission.AddChild(VietLifePermissions.KpiNhanVien.Create, L("Permission:Catalog.KpiNhanVien.Create"));
        kpiPermission.AddChild(VietLifePermissions.KpiNhanVien.Update, L("Permission:Catalog.KpiNhanVien.Update"));
        kpiPermission.AddChild(VietLifePermissions.KpiNhanVien.Delete, L("Permission:Catalog.KpiNhanVien.Delete"));

        // --- K? ho?ch công vi?c ---
        var keHoachPermission = kpiPermission.AddChild(VietLifePermissions.KpiNhanVien.KeHoachCongViec.Default,L("Permission:Catalog.KpiNhanVien.KeHoachCongViec"));
        keHoachPermission.AddChild(VietLifePermissions.KpiNhanVien.KeHoachCongViec.View, L("Permission:Catalog.KpiNhanVien.KeHoachCongViec.View"));
        keHoachPermission.AddChild(VietLifePermissions.KpiNhanVien.KeHoachCongViec.Create, L("Permission:Catalog.KpiNhanVien.KeHoachCongViec.Create"));
        keHoachPermission.AddChild(VietLifePermissions.KpiNhanVien.KeHoachCongViec.Update, L("Permission:Catalog.KpiNhanVien.KeHoachCongViec.Update"));
        keHoachPermission.AddChild(VietLifePermissions.KpiNhanVien.KeHoachCongViec.Delete, L("Permission:Catalog.KpiNhanVien.KeHoachCongViec.Delete"));

        // --- M?c tiêu KPI ---
        var mucTieuPermission = kpiPermission.AddChild(VietLifePermissions.KpiNhanVien.MucTieuKpi.Default,L("Permission:Catalog.KpiNhanVien.MucTieuKpi"));
        mucTieuPermission.AddChild(VietLifePermissions.KpiNhanVien.MucTieuKpi.View, L("Permission:Catalog.KpiNhanVien.MucTieuKpi.View"));
        mucTieuPermission.AddChild(VietLifePermissions.KpiNhanVien.MucTieuKpi.Create, L("Permission:Catalog.KpiNhanVien.MucTieuKpi.Create"));
        mucTieuPermission.AddChild(VietLifePermissions.KpiNhanVien.MucTieuKpi.Update, L("Permission:Catalog.KpiNhanVien.MucTieuKpi.Update"));
        mucTieuPermission.AddChild(VietLifePermissions.KpiNhanVien.MucTieuKpi.Delete, L("Permission:Catalog.KpiNhanVien.MucTieuKpi.Delete"));

        // --- Ti?n ?? làm vi?c ---
        var tienDoPermission = kpiPermission.AddChild(VietLifePermissions.KpiNhanVien.TienDoLamViec.Default,L("Permission:Catalog.KpiNhanVien.TienDoLamViec"));
        tienDoPermission.AddChild(VietLifePermissions.KpiNhanVien.TienDoLamViec.View, L("Permission:Catalog.KpiNhanVien.TienDoLamViec.View"));
        tienDoPermission.AddChild(VietLifePermissions.KpiNhanVien.TienDoLamViec.Create, L("Permission:Catalog.KpiNhanVien.TienDoLamViec.Create"));
        tienDoPermission.AddChild(VietLifePermissions.KpiNhanVien.TienDoLamViec.Update, L("Permission:Catalog.KpiNhanVien.TienDoLamViec.Update"));
        tienDoPermission.AddChild(VietLifePermissions.KpiNhanVien.TienDoLamViec.Delete, L("Permission:Catalog.KpiNhanVien.TienDoLamViec.Delete"));

        // --- ?ánh giá KPI ---
        var danhGiaPermission = kpiPermission.AddChild(VietLifePermissions.KpiNhanVien.DanhGiaKpi.Default,L("Permission:Catalog.KpiNhanVien.DanhGiaKpi"));
        danhGiaPermission.AddChild(VietLifePermissions.KpiNhanVien.DanhGiaKpi.View, L("Permission:Catalog.KpiNhanVien.DanhGiaKpi.View"));
        danhGiaPermission.AddChild(VietLifePermissions.KpiNhanVien.DanhGiaKpi.Create, L("Permission:Catalog.KpiNhanVien.DanhGiaKpi.Create"));
        danhGiaPermission.AddChild(VietLifePermissions.KpiNhanVien.DanhGiaKpi.Update, L("Permission:Catalog.KpiNhanVien.DanhGiaKpi.Update"));
        danhGiaPermission.AddChild(VietLifePermissions.KpiNhanVien.DanhGiaKpi.Delete, L("Permission:Catalog.KpiNhanVien.DanhGiaKpi.Delete"));

        // ?? Ph? c?p nhân viên
        var phuCapNhanVienPermission = catalogGroup.AddPermission(VietLifePermissions.PhuCapNhanVien.Default, L("Permission:Catalog.PhuCapNhanVien"));
        phuCapNhanVienPermission.AddChild(VietLifePermissions.PhuCapNhanVien.View, L("Permission:Catalog.PhuCapNhanVien.View"));
        phuCapNhanVienPermission.AddChild(VietLifePermissions.PhuCapNhanVien.Create, L("Permission:Catalog.PhuCapNhanVien.Create"));
        phuCapNhanVienPermission.AddChild(VietLifePermissions.PhuCapNhanVien.Update, L("Permission:Catalog.PhuCapNhanVien.Update"));
        phuCapNhanVienPermission.AddChild(VietLifePermissions.PhuCapNhanVien.Delete, L("Permission:Catalog.PhuCapNhanVien.Delete"));

        // ?? L??ng nhân viên
        var luongNhanVienPermission = catalogGroup.AddPermission(VietLifePermissions.LuongNhanVien.Default, L("Permission:Catalog.LuongNhanVien"));
        luongNhanVienPermission.AddChild(VietLifePermissions.LuongNhanVien.View, L("Permission:Catalog.LuongNhanVien.View"));
        luongNhanVienPermission.AddChild(VietLifePermissions.LuongNhanVien.Create, L("Permission:Catalog.LuongNhanVien.Create"));
        luongNhanVienPermission.AddChild(VietLifePermissions.LuongNhanVien.Update, L("Permission:Catalog.LuongNhanVien.Update"));
        luongNhanVienPermission.AddChild(VietLifePermissions.LuongNhanVien.Delete, L("Permission:Catalog.LuongNhanVien.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VietLifeResource>(name);
    }
}
