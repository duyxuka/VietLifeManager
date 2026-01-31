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

        //Business
        var businessGroup = context.AddGroup(VietLifePermissions.BusinessGroupName, L("Permission:Business"));

        //TuongTac
        var tuongTacGroup = context.AddGroup(VietLifePermissions.TuongTacGroupName, L("Permission:TuongTac"));

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
        luongNhanVienPermission.AddChild(VietLifePermissions.LuongNhanVien.ViewAll, L("Permission:Catalog.LuongNhanVien.ViewAll"));
        luongNhanVienPermission.AddChild(VietLifePermissions.LuongNhanVien.Create, L("Permission:Catalog.LuongNhanVien.Create"));
        luongNhanVienPermission.AddChild(VietLifePermissions.LuongNhanVien.Update, L("Permission:Catalog.LuongNhanVien.Update"));
        luongNhanVienPermission.AddChild(VietLifePermissions.LuongNhanVien.Delete, L("Permission:Catalog.LuongNhanVien.Delete"));

        // === LO?I H?P ??NG ===
        var loaiHopDongPermission = catalogGroup.AddPermission(VietLifePermissions.LoaiHopDong.Default, L("Permission:Catalog.LoaiHopDong"));
        loaiHopDongPermission.AddChild(VietLifePermissions.LoaiHopDong.View, L("Permission:Catalog.LoaiHopDong.View"));
        loaiHopDongPermission.AddChild(VietLifePermissions.LoaiHopDong.Create, L("Permission:Catalog.LoaiHopDong.Create"));
        loaiHopDongPermission.AddChild(VietLifePermissions.LoaiHopDong.Update, L("Permission:Catalog.LoaiHopDong.Update"));
        loaiHopDongPermission.AddChild(VietLifePermissions.LoaiHopDong.Delete, L("Permission:Catalog.LoaiHopDong.Delete"));

        // === H?P ??NG NHÂN VIÊN ===
        var hopDongNhanVienPermission = catalogGroup.AddPermission(VietLifePermissions.HopDongNhanVien.Default, L("Permission:Catalog.HopDongNhanVien"));
        hopDongNhanVienPermission.AddChild(VietLifePermissions.HopDongNhanVien.View, L("Permission:Catalog.HopDongNhanVien.View"));
        hopDongNhanVienPermission.AddChild(VietLifePermissions.HopDongNhanVien.Create, L("Permission:Catalog.HopDongNhanVien.Create"));
        hopDongNhanVienPermission.AddChild(VietLifePermissions.HopDongNhanVien.Update, L("Permission:Catalog.HopDongNhanVien.Update"));
        hopDongNhanVienPermission.AddChild(VietLifePermissions.HopDongNhanVien.Delete, L("Permission:Catalog.HopDongNhanVien.Delete"));
        hopDongNhanVienPermission.AddChild(VietLifePermissions.HopDongNhanVien.Approve, L("Permission:Catalog.HopDongNhanVien.Approve")); // n?u c?n duy?t

        //Business
        // === NHÓM S?N PH?M ===
        var nhomSanPhamPermission = businessGroup.AddPermission(VietLifePermissions.NhomSanPham.Default, L("Permission:Business.NhomSanPham"));
        nhomSanPhamPermission.AddChild(VietLifePermissions.NhomSanPham.View, L("Permission:Business.NhomSanPham.View"));
        nhomSanPhamPermission.AddChild(VietLifePermissions.NhomSanPham.Create, L("Permission:Business.NhomSanPham.Create"));
        nhomSanPhamPermission.AddChild(VietLifePermissions.NhomSanPham.Update, L("Permission:Business.NhomSanPham.Update"));
        nhomSanPhamPermission.AddChild(VietLifePermissions.NhomSanPham.Delete, L("Permission:Business.NhomSanPham.Delete"));

        // === ??N V? TÍNH ===
        var donViTinhPermission = businessGroup.AddPermission(VietLifePermissions.DonViTinh.Default, L("Permission:Business.DonViTinh"));
        donViTinhPermission.AddChild(VietLifePermissions.DonViTinh.View, L("Permission:Business.DonViTinh.View"));
        donViTinhPermission.AddChild(VietLifePermissions.DonViTinh.Create, L("Permission:Business.DonViTinh.Create"));
        donViTinhPermission.AddChild(VietLifePermissions.DonViTinh.Update, L("Permission:Business.DonViTinh.Update"));
        donViTinhPermission.AddChild(VietLifePermissions.DonViTinh.Delete, L("Permission:Business.DonViTinh.Delete"));

        // === S?N PH?M ===
        var sanPhamPermission = businessGroup.AddPermission(VietLifePermissions.SanPham.Default, L("Permission:Business.SanPham"));
        sanPhamPermission.AddChild(VietLifePermissions.SanPham.View, L("Permission:Business.SanPham.View"));
        sanPhamPermission.AddChild(VietLifePermissions.SanPham.Create, L("Permission:Business.SanPham.Create"));
        sanPhamPermission.AddChild(VietLifePermissions.SanPham.Update, L("Permission:Business.SanPham.Update"));
        sanPhamPermission.AddChild(VietLifePermissions.SanPham.Delete, L("Permission:Business.SanPham.Delete"));

        //Kho Hàng
        var khoHangPermission = businessGroup.AddPermission(VietLifePermissions.KhoHang.Default, L("Permission:Business.KhoHang"));
        khoHangPermission.AddChild(VietLifePermissions.KhoHang.View, L("Permission:Business.KhoHang.View"));
        khoHangPermission.AddChild(VietLifePermissions.KhoHang.Create, L("Permission:Business.KhoHang.Create"));
        khoHangPermission.AddChild(VietLifePermissions.KhoHang.Update, L("Permission:Business.KhoHang.Update"));
        khoHangPermission.AddChild(VietLifePermissions.KhoHang.Delete, L("Permission:Business.KhoHang.Delete"));

        //Thành Ph?
        var thanhPhoPermission = businessGroup.AddPermission(VietLifePermissions.ThanhPho.Default, L("Permission:Business.ThanhPho"));
        thanhPhoPermission.AddChild(VietLifePermissions.ThanhPho.View, L("Permission:Business.ThanhPho.View"));
        thanhPhoPermission.AddChild(VietLifePermissions.ThanhPho.Create, L("Permission:Business.ThanhPho.Create"));
        thanhPhoPermission.AddChild(VietLifePermissions.ThanhPho.Update, L("Permission:Business.ThanhPho.Update"));
        thanhPhoPermission.AddChild(VietLifePermissions.ThanhPho.Delete, L("Permission:Business.ThanhPho.Delete"));

        var tienTePermission = businessGroup.AddPermission(VietLifePermissions.TienTe.Default, L("Permission:Business.TienTe"));
        tienTePermission.AddChild(VietLifePermissions.TienTe.View, L("Permission:Business.TienTe.View"));
        tienTePermission.AddChild(VietLifePermissions.TienTe.Create, L("Permission:Business.TienTe.Create"));
        tienTePermission.AddChild(VietLifePermissions.TienTe.Update, L("Permission:Business.TienTe.Update"));
        tienTePermission.AddChild(VietLifePermissions.TienTe.Delete, L("Permission:Business.TienTe.Delete"));

        var loaiKhachHangPermission = businessGroup.AddPermission(VietLifePermissions.LoaiKhachHang.Default, L("Permission:Business.LoaiKhachHang"));
        loaiKhachHangPermission.AddChild(VietLifePermissions.LoaiKhachHang.View, L("Permission:Business.LoaiKhachHang.View"));
        loaiKhachHangPermission.AddChild(VietLifePermissions.LoaiKhachHang.Create, L("Permission:Business.LoaiKhachHang.Create"));
        loaiKhachHangPermission.AddChild(VietLifePermissions.LoaiKhachHang.Update, L("Permission:Business.LoaiKhachHang.Update"));
        loaiKhachHangPermission.AddChild(VietLifePermissions.LoaiKhachHang.Delete, L("Permission:Business.LoaiKhachHang.Delete"));

        var khachHangPermission = businessGroup.AddPermission(VietLifePermissions.KhachHang.Default, L("Permission:Business.KhachHang"));
        khachHangPermission.AddChild(VietLifePermissions.KhachHang.View, L("Permission:Business.KhachHang.View"));
        khachHangPermission.AddChild(VietLifePermissions.KhachHang.Create, L("Permission:Business.KhachHang.Create"));
        khachHangPermission.AddChild(VietLifePermissions.KhachHang.Update, L("Permission:Business.KhachHang.Update"));
        khachHangPermission.AddChild(VietLifePermissions.KhachHang.Delete, L("Permission:Business.KhachHang.Delete"));

        var loaiThuChiPermission = businessGroup.AddPermission(VietLifePermissions.LoaiThuChi.Default, L("Permission:Business.LoaiThuChi"));
        loaiThuChiPermission.AddChild(VietLifePermissions.LoaiThuChi.View, L("Permission:Business.LoaiThuChi.View"));
        loaiCheDoPermission.AddChild(VietLifePermissions.LoaiThuChi.Create, L("Permission:Business.LoaiThuChi.Create"));
        loaiThuChiPermission.AddChild(VietLifePermissions.LoaiThuChi.Update, L("Permission:Business.LoaiThuChi.Update"));
        loaiThuChiPermission.AddChild(VietLifePermissions.LoaiThuChi.Delete, L("Permission:Business.LoaiThuChi.Delete"));

        var taiKhoanKeToanPermission = businessGroup.AddPermission(VietLifePermissions.TaiKhoanKeToan.Default, L("Permission:Business.TaiKhoanKeToan"));
        taiKhoanKeToanPermission.AddChild(VietLifePermissions.TaiKhoanKeToan.View, L("Permission:Business.TaiKhoanKeToan.View"));
        taiKhoanKeToanPermission.AddChild(VietLifePermissions.TaiKhoanKeToan.Create, L("Permission:Business.TaiKhoanKeToan.Create"));
        taiKhoanKeToanPermission.AddChild(VietLifePermissions.TaiKhoanKeToan.Update, L("Permission:Business.TaiKhoanKeToan.Update"));
        taiKhoanKeToanPermission.AddChild(VietLifePermissions.TaiKhoanKeToan.Delete, L("Permission:Business.TaiKhoanKeToan.Delete"));

        var thuChiPermission = businessGroup.AddPermission(VietLifePermissions.ThuChi.Default, L("Permission:Business.ThuChi"));
        thuChiPermission.AddChild(VietLifePermissions.ThuChi.View, L("Permission:Business.ThuChi.View"));
        thuChiPermission.AddChild(VietLifePermissions.ThuChi.Create, L("Permission:Business.ThuChi.Create"));
        thuChiPermission.AddChild(VietLifePermissions.ThuChi.Update, L("Permission:Business.ThuChi.Update"));
        thuChiPermission.AddChild(VietLifePermissions.ThuChi.Delete, L("Permission:Business.ThuChi.Delete"));

        var baoGiaPermission = businessGroup.AddPermission(VietLifePermissions.BaoGia.Default, L("Permission:Business.BaoGia"));
        baoGiaPermission.AddChild(VietLifePermissions.BaoGia.View, L("Permission:Business.BaoGia.View"));
        baoGiaPermission.AddChild(VietLifePermissions.BaoGia.Create, L("Permission:Business.BaoGia.Create"));
        baoGiaPermission.AddChild(VietLifePermissions.BaoGia.Update, L("Permission:Business.BaoGia.Update"));
        baoGiaPermission.AddChild(VietLifePermissions.BaoGia.Delete, L("Permission:Business.BaoGia.Delete"));

        var loaiDonHangPermission = businessGroup.AddPermission(VietLifePermissions.LoaiDonHang.Default, L("Permission:Business.LoaiDonHang"));
        loaiDonHangPermission.AddChild(VietLifePermissions.LoaiDonHang.View, L("Permission:Business.LoaiDonHang.View"));
        loaiDonHangPermission.AddChild(VietLifePermissions.LoaiDonHang.Create, L("Permission:Business.LoaiDonHang.Create"));
        loaiDonHangPermission.AddChild(VietLifePermissions.LoaiDonHang.Update, L("Permission:Business.LoaiDonHang.Update"));
        loaiDonHangPermission.AddChild(VietLifePermissions.LoaiDonHang.Delete, L("Permission:Business.LoaiDonHang.Delete"));

        var donHangPermission = businessGroup.AddPermission(VietLifePermissions.DonHang.Default, L("Permission:Business.DonHang"));
        donHangPermission.AddChild(VietLifePermissions.DonHang.View, L("Permission:Business.DonHang.View"));
        donHangPermission.AddChild(VietLifePermissions.DonHang.Create, L("Permission:Business.DonHang.Create"));
        donHangPermission.AddChild(VietLifePermissions.DonHang.Update, L("Permission:Business.DonHang.Update"));
        donHangPermission.AddChild(VietLifePermissions.DonHang.Delete, L("Permission:Business.DonHang.Delete"));

        var phieuNhapXuatPermission = businessGroup.AddPermission(VietLifePermissions.PhieuNhapXuat.Default, L("Permission:Business.PhieuNhapXuat"));
        phieuNhapXuatPermission.AddChild(VietLifePermissions.PhieuNhapXuat.View, L("Permission:Business.PhieuNhapXuat.View"));
        phieuNhapXuatPermission.AddChild(VietLifePermissions.PhieuNhapXuat.Create, L("Permission:Business.PhieuNhapXuat.Create"));
        phieuNhapXuatPermission.AddChild(VietLifePermissions.PhieuNhapXuat.Update, L("Permission:Business.PhieuNhapXuat.Update"));
        phieuNhapXuatPermission.AddChild(VietLifePermissions.PhieuNhapXuat.Delete, L("Permission:Business.PhieuNhapXuat.Delete"));

        var loaiNhapXuatPermission = businessGroup.AddPermission(VietLifePermissions.LoaiNhapXuat.Default, L("Permission:Business.LoaiNhapXuat"));
        loaiNhapXuatPermission.AddChild(VietLifePermissions.LoaiNhapXuat.View, L("Permission:Business.LoaiNhapXuat.View"));
        loaiNhapXuatPermission.AddChild(VietLifePermissions.LoaiNhapXuat.Create, L("Permission:Business.LoaiNhapXuat.Create"));
        loaiNhapXuatPermission.AddChild(VietLifePermissions.LoaiNhapXuat.Update, L("Permission:Business.LoaiNhapXuat.Update"));
        loaiNhapXuatPermission.AddChild(VietLifePermissions.LoaiNhapXuat.Delete, L("Permission:Business.LoaiNhapXuat.Delete"));

        //TuongTac
        var tinTucPermission = tuongTacGroup.AddPermission(VietLifePermissions.TinTuc.Default, L("Permission:TuongTac.TinTuc"));
        tinTucPermission.AddChild(VietLifePermissions.TinTuc.View, L("Permission:TuongTac.TinTuc.View"));
        tinTucPermission.AddChild(VietLifePermissions.TinTuc.Create, L("Permission:TuongTac.TinTuc.Create"));
        tinTucPermission.AddChild(VietLifePermissions.TinTuc.Update, L("Permission:TuongTac.TinTuc.Update"));
        tinTucPermission.AddChild(VietLifePermissions.TinTuc.Delete, L("Permission:TuongTac.TinTuc.Delete"));

        var lienHePermission = tuongTacGroup.AddPermission(VietLifePermissions.LienHe.Default, L("Permission:TuongTac.LienHe"));
        lienHePermission.AddChild(VietLifePermissions.LienHe.View, L("Permission:TuongTac.LienHe.View"));
        lienHePermission.AddChild(VietLifePermissions.LienHe.Create, L("Permission:TuongTac.LienHe.Create"));
        lienHePermission.AddChild(VietLifePermissions.LienHe.Update, L("Permission:TuongTac.LienHe.Update"));
        lienHePermission.AddChild(VietLifePermissions.LienHe.Delete, L("Permission:TuongTac.LienHe.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VietLifeResource>(name);
    }
}
