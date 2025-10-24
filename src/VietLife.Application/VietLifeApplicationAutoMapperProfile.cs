using AutoMapper;
using VietLife.Catalog.ChamCongs;
using VietLife.Catalog.CheDos.CheDoNhanViens;
using VietLife.Catalog.CheDos.LoaiCheDos;
using VietLife.Catalog.ChiNhanhs;
using VietLife.Catalog.ChucVus;
using VietLife.Catalog.KPIs.DanhGiaKpis;
using VietLife.Catalog.KPIs.KeHoachCongViecs;
using VietLife.Catalog.KPIs.KpiNhanViens;
using VietLife.Catalog.KPIs.MucTieuKpis;
using VietLife.Catalog.KPIs.TienDoLamViecs;
using VietLife.Catalog.LichLamViecs;
using VietLife.Catalog.LuongNhanViens;
using VietLife.Catalog.Manufacturers;
using VietLife.Catalog.PhongBans;
using VietLife.Catalog.PhuCapNhanViens;
using VietLife.Catalog.ProductAttributes;
using VietLife.Catalog.ProductCategories;
using VietLife.Catalog.Products;
using VietLife.ChamCongs;
using VietLife.CheDoNhanViens;
using VietLife.ChiNhanhs;
using VietLife.Chucvus;
using VietLife.KPINhanViens;
using VietLife.LichLamViecs;
using VietLife.LuongNhanViens;
using VietLife.Manufacturers;
using VietLife.NhanViens;
using VietLife.PhongBans;
using VietLife.PhuCapNhanViens;
using VietLife.ProductAttributes;
using VietLife.ProductCategories;
using VietLife.Products;
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

        //ProductCategrory
        CreateMap<ProductCategory, ProductCategoryDto>();
        CreateMap<ProductCategory, ProductCategoryInListDto>();
        CreateMap<CreateUpdateProductCategoryDto, ProductCategory>();

        //Product
        CreateMap<Product, ProductDto>();
        CreateMap<Product, ProductInListDto>();
        CreateMap<CreateUpdateProductDto, Product>();

        //Manufacturer
        CreateMap<Manufacturer, ManufacturerDto>();
        CreateMap<Manufacturer, ManufacturerInListDto>();
        CreateMap<CreateUpdateManufacturerDto, Manufacturer>();

        //ProductAttribute
        CreateMap<ProductAttribute, ProductAttributeDto>();
        CreateMap<ProductAttribute, ProductAttributeInListDto>();
        CreateMap<CreateUpdateProductAttributeDto, ProductAttribute>();

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
    }
}
