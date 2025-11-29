using AutoMapper;
using VietLife.Business.BaoGias;
using VietLife.Business.BaoGiasList.BaoGias;
using VietLife.Business.BaoGiasList.ChiTietBaoGias;
using VietLife.Business.DonHangs;
using VietLife.Business.DonHangsList.ChiTietDonHangs;
using VietLife.Business.DonHangsList.DonHangs;
using VietLife.Business.DonHangsList.LoaiDonHangs;
using VietLife.Business.KhachHangs;
using VietLife.Business.KhachHangsList.KhachHangs;
using VietLife.Business.KhachHangsList.LoaiKhachHangs;
using VietLife.Business.KhoHangs;
using VietLife.Business.NhapXuats.ChiTietPhieuNhapXuats;
using VietLife.Business.NhapXuats.LoaiNhapXuats;
using VietLife.Business.NhapXuats.PhieuNhapXuats;
using VietLife.Business.PhieuNhapXuats;
using VietLife.Business.SanPhams;
using VietLife.Business.SanPhamsList.DonViTinhs;
using VietLife.Business.SanPhamsList.NhomSanPhams;
using VietLife.Business.SanPhamsList.SanPhams;
using VietLife.Business.ThanhPhos;
using VietLife.Business.ThuChis;
using VietLife.Business.ThuChisList.LoaiThuChis;
using VietLife.Business.ThuChisList.TaiKhoanKeToans;
using VietLife.Business.ThuChisList.ThuChis;
using VietLife.Business.TienTes;
using VietLife.Catalog.ChamCongs;
using VietLife.Catalog.CheDoNhanViens;
using VietLife.Catalog.CheDos.CheDoNhanViens;
using VietLife.Catalog.CheDos.LoaiCheDos;
using VietLife.Catalog.ChiNhanhs;
using VietLife.Catalog.Chucvus;
using VietLife.Catalog.ChucVus;
using VietLife.Catalog.HopDongs.HopDongNhanViens;
using VietLife.Catalog.HopDongs.LoaiHopDongs;
using VietLife.Catalog.KPINhanViens;
using VietLife.Catalog.KPIs.DanhGiaKpis;
using VietLife.Catalog.KPIs.KeHoachCongViecs;
using VietLife.Catalog.KPIs.KpiNhanViens;
using VietLife.Catalog.KPIs.MucTieuKpis;
using VietLife.Catalog.KPIs.TienDoLamViecs;
using VietLife.Catalog.LichLamViecs;
using VietLife.Catalog.LuongNhanViens;
using VietLife.Catalog.NhanViens;
using VietLife.Catalog.PhongBans;
using VietLife.Catalog.PhuCapNhanViens;
using VietLife.Roles;
using VietLife.System.Roles;
using VietLife.System.Users;
using Volo.Abp.Identity;

namespace VietLife;

public class VietLifeApplicationAutoMapperProfile : Profile
{
    public VietLifeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */


        //PhongBan
        CreateMap<PhongBan, PhongBanDto>();
        CreateMap<PhongBan, PhongBanInListDto>();
        CreateMap<CreateUpdatePhongBanDto, PhongBan>();

        //ChucVu
        CreateMap<ChucVu, ChucVuDto>();
        CreateMap<ChucVu, ChucVuInListDto>();
        CreateMap<CreateUpdateChucVuDto, ChucVu>();

        //ChamCong
        CreateMap<ChamCong, ChamCongDto>();
        CreateMap<ChamCong, ChamCongInListDto>();
        CreateMap<CreateUpdateChamCongDto, ChamCong>();

        //ChiNhanh
        CreateMap<ChiNhanh, ChiNhanhDto>();
        CreateMap<ChiNhanh, ChiNhanhInListDto>();
        CreateMap<CreateUpdateChiNhanhDto, ChiNhanh>();

        //LichLamViec
        CreateMap<LichLamViec, LichLamViecDto>();
        CreateMap<LichLamViec, LichLamViecInListDto>();
        CreateMap<CreateUpdateLichLamViecDto, LichLamViec>();

        //CheDoNhanVien
        CreateMap<LoaiCheDo, LoaiCheDoDto>();
        CreateMap<LoaiCheDo, LoaiCheDoInListDto>();
        CreateMap<CreateUpdateLoaiCheDoDto, LoaiCheDo>();
        CreateMap<CheDoNhanVien, CheDoNhanVienDto>();
        CreateMap<CheDoNhanVien, CheDoNhanVienInListDto>();
        CreateMap<CreateUpdateCheDoNhanVienDto, CheDoNhanVien>();

        //PhuCapNhanVien
        CreateMap<PhuCapNhanVien, PhuCapNhanVienDto>();
        CreateMap<PhuCapNhanVien, PhuCapNhanVienInListDto>();
        CreateMap<CreateUpdatePhuCapNhanVienDto, PhuCapNhanVien>();

        //KPI
        CreateMap<DanhGiaKpi, DanhGiaKpiDto>();
        CreateMap<DanhGiaKpi, DanhGiaKpiInListDto>();
        CreateMap<CreateUpdateDanhGiaKpiDto, DanhGiaKpi>();
        CreateMap<KeHoachCongViec, KeHoachCongViecDto>();
        CreateMap<KeHoachCongViec, KeHoachCongViecInListDto>();
        CreateMap<CreateUpdateKeHoachCongViecDto, KeHoachCongViec>();
        CreateMap<KpiNhanVien, KpiNhanVienDto>();
        CreateMap<KpiNhanVien, KpiNhanVienInListDto>();
        CreateMap<CreateUpdateKpiNhanVienDto, KpiNhanVien>();
        CreateMap<MucTieuKpi, MucTieuKpiDto>();
        CreateMap<MucTieuKpi, MucTieuKpiInListDto>();
        CreateMap<CreateUpdateMucTieuKpiDto, MucTieuKpi>();
        CreateMap<TienDoLamViec, TienDoLamViecDto>();
        CreateMap<TienDoLamViec, TienDoLamViecInListDto>();
        CreateMap<CreateUpdateTienDoLamViecDto, TienDoLamViec>();

        //LuongNhanVien
        CreateMap<LuongNhanVien, LuongNhanVienDto>();
        CreateMap<LuongNhanVien, LuongNhanVienInListDto>();
        CreateMap<CreateUpdateLuongNhanVienDto, LuongNhanVien>();

        //Role
        CreateMap<IdentityRole, RoleDto>().ForMember(x => x.Description,
             map => map.MapFrom(x => x.ExtraProperties.ContainsKey(RoleConsts.DescriptionFieldName)
             ?
             x.ExtraProperties[RoleConsts.DescriptionFieldName]
             :
             null));
        CreateMap<IdentityRole, RoleInListDto>().ForMember(x => x.Description,
            map => map.MapFrom(x => x.ExtraProperties.ContainsKey(RoleConsts.DescriptionFieldName)
            ?
            x.ExtraProperties[RoleConsts.DescriptionFieldName]
            :
            null));
        CreateMap<CreateUpdateRoleDto, IdentityRole>();

        //User
        CreateMap<NhanVien, UserDto>();
        CreateMap<NhanVien, UserInListDto>();

        //Business

        // NhomSanPham
        CreateMap<NhomSanPham, NhomSanPhamDto>();
        CreateMap<NhomSanPham, NhomSanPhamInListDto>();
        CreateMap<CreateUpdateNhomSanPhamDto, NhomSanPham>();

        //Product
        CreateMap<SanPham, SanPhamDto>();
        CreateMap<SanPham, SanPhamInListDto>();
        CreateMap<CreateUpdateSanPhamDto, SanPham>();

        // DonViTinh
        CreateMap<DonViTinh, DonViTinhDto>();
        CreateMap<DonViTinh, DonViTinhInListDto>();
        CreateMap<CreateUpdateDonViTinhDto, DonViTinh>();

        // TienTe
        CreateMap<TienTe, TienTeDto>();
        CreateMap<TienTe, TienTeInListDto>();
        CreateMap<CreateUpdateTienTeDto, TienTe>();

        // ThuChi
        CreateMap<ThuChi, ThuChiDto>();
        CreateMap<ThuChi, ThuChiInListDto>();
        CreateMap<CreateUpdateThuChiDto, ThuChi>();

        //LoaiThuChi
        CreateMap<LoaiThuChi, LoaiThuChiDto>();
        CreateMap<LoaiThuChi, LoaiThuChiInListDto>();
        CreateMap<CreateUpdateLoaiThuChiDto, LoaiThuChi>();

        //TaiKhoanKeToan
        CreateMap<TaiKhoanKeToan, TaiKhoanKeToanDto>();
        CreateMap<TaiKhoanKeToan, TaiKhoanKeToanInListDto>();
        CreateMap<CreateUpdateTaiKhoanKeToanDto, TaiKhoanKeToan>();

        // ThanhPho
        CreateMap<ThanhPho, ThanhPhoDto>();
        CreateMap<ThanhPho, ThanhPhoInListDto>();
        CreateMap<CreateUpdateThanhPhoDto, ThanhPho>();

        // LoaiHopDong
        CreateMap<LoaiHopDong, LoaiHopDongDto>();
        CreateMap<LoaiHopDong, LoaiHopDongInListDto>();
        CreateMap<CreateUpdateLoaiHopDongDto, LoaiHopDong>();

        // HopDongNhanVien
        CreateMap<HopDongNhanVien, HopDongNhanVienDto>();
        CreateMap<HopDongNhanVien, HopDongNhanVienInListDto>();
        CreateMap<CreateUpdateHopDongNhanVienDto, HopDongNhanVien>();

        // KhoHang
        CreateMap<KhoHang, KhoHangDto>();
        CreateMap<KhoHang, KhoHangInListDto>();
        CreateMap<CreateUpdateKhoHangDto, KhoHang>();

        // LoaiNhapXuat
        CreateMap<LoaiNhapXuat, LoaiNhapXuatDto>();
        CreateMap<LoaiNhapXuat, LoaiNhapXuatInListDto>();
        CreateMap<CreateUpdateLoaiNhapXuatDto, LoaiNhapXuat>();

        // PhieuNhapXuat
        CreateMap<PhieuNhapXuat, PhieuNhapXuatDto>();
        CreateMap<PhieuNhapXuat, PhieuNhapXuatInListDto>();
        CreateMap<CreateUpdatePhieuNhapXuatDto, PhieuNhapXuat>().ForMember(x => x.ChiTietPhieuNhapXuats, opt => opt.Ignore());


        // ChiTietPhieuNhapXuat
        CreateMap<ChiTietPhieuNhapXuat, ChiTietPhieuNhapXuatDto>();
        CreateMap<ChiTietPhieuNhapXuat, ChiTietPhieuNhapXuatInListDto>();
        CreateMap<CreateUpdateChiTietPhieuNhapXuatDto, ChiTietPhieuNhapXuat>();

        // LoaiKhachHang
        CreateMap<LoaiKhachHang, LoaiKhachHangDto>();
        CreateMap<LoaiKhachHang, LoaiKhachHangInListDto>();
        CreateMap<CreateUpdateLoaiKhachHangDto, LoaiKhachHang>();

        // KhachHang
        CreateMap<KhachHang, KhachHangDto>();
        CreateMap<KhachHang, KhachHangInListDto>();
        CreateMap<CreateUpdateKhachHangDto, KhachHang>();

        // LoaiDonHang
        CreateMap<LoaiDonHang, LoaiDonHangDto>();
        CreateMap<LoaiDonHang, LoaiDonHangInListDto>();
        CreateMap<CreateUpdateLoaiDonHangDto, LoaiDonHang>();

        // DonHang
        CreateMap<DonHang, DonHangDto>();
        CreateMap<DonHang, DonHangInListDto>();
        CreateMap<CreateUpdateDonHangDto, DonHang>().ForMember(x => x.ChiTietDonHangs, opt => opt.Ignore());

        // ChiTietDonHang
        CreateMap<ChiTietDonHang, ChiTietDonHangDto>();
        CreateMap<ChiTietDonHang, ChiTietDonHangInListDto>();
        CreateMap<CreateUpdateChiTietDonHangDto, ChiTietDonHang>();

        // BaoGia
        CreateMap<BaoGia, BaoGiaDto>();
        CreateMap<BaoGia, BaoGiaInListDto>();
        CreateMap<CreateUpdateBaoGiaDto, BaoGia>().ForMember(x => x.ChiTietBaoGias, opt => opt.Ignore());

        // ChiTietBaoGia
        CreateMap<ChiTietBaoGia, ChiTietBaoGiaDto>();
        CreateMap<ChiTietBaoGia, ChiTietBaoGiaInListDto>();
        CreateMap<CreateUpdateChiTietBaoGiaDto, ChiTietBaoGia>();

    }
}
