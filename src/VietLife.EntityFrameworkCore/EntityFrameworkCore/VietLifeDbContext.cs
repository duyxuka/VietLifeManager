using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using VietLife.IdentitySettings;
using System.Reflection.Emit;
using VietLife.Catalog.NhanViens;
using VietLife.Catalog.KPINhanViens;
using VietLife.Catalog.Chucvus;
using VietLife.Catalog.LichLamViecs;
using VietLife.Catalog.LuongNhanViens;
using VietLife.Catalog.PhuCapNhanViens;
using VietLife.Catalog.PhongBans;
using VietLife.Catalog.ChiNhanhs;
using VietLife.Catalog.CheDoNhanViens;
using VietLife.Catalog.ChamCongs;
using VietLife.Business.SanPhams;
using VietLife.Configurations.Business.Sanphams;
using VietLife.Configurations.Catalog.NhanViens;
using VietLife.Configurations.Catalog.ChamCongs;
using VietLife.Configurations.Catalog.PhongBans;
using VietLife.Configurations.Catalog.ChucVus;
using VietLife.Configurations.Catalog.LichLamViecs;
using VietLife.Configurations.Catalog.LuongNhanViens;
using VietLife.Configurations.Catalog.KpiNhanViens;
using VietLife.Configurations.Catalog.CheDoNhanViens;
using VietLife.Configurations.Catalog.PhuCapNhanViens;
using VietLife.Configurations.Catalog.ChiNhanhs;
using VietLife.Business.TienTes;
using VietLife.Business.ThuChis;
using VietLife.Business.ThanhPhos;
using VietLife.Business.PhieuNhapXuats;
using VietLife.Business.KhoHangs;
using VietLife.Business.KhachHangs;
using VietLife.Business.DonHangs;
using VietLife.Business.BaoGias;
using VietLife.Configurations.Business.BaoGias;
using VietLife.Configurations.Business.DonHangs;
using VietLife.Configurations.Business.KhachHangs;
using VietLife.Configurations.Business.KhoHangs;
using VietLife.Configurations.Business.PhieuNhapXuats;
using VietLife.Configurations.Business.ThanhPhos;
using VietLife.Configurations.Business.TienTes;
using VietLife.Configurations.Business.ThuChis;

namespace VietLife.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class VietLifeDbContext :
    AbpDbContext<VietLifeDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */


    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    //Vietlife
    public DbSet<IdentitySetting> IdentitySettings { get; set; }
    public DbSet<PhongBan> PhongBans { get; set; }
    public DbSet<ChucVu> ChucVus { get; set; }
    public DbSet<ChamCong> ChamCongs { get; set; }
    public DbSet<LichLamViec> LichLamViecs { get; set; }
    public DbSet<LoaiCheDo> LoaiCheDos { get; set; }
    public DbSet<LuongNhanVien> LuongNhanViens { get; set; }
    public DbSet<KpiNhanVien> KpiNhanViens { get; set; }
    public DbSet<CheDoNhanVien> CheDoNhanViens { get; set; }
    public DbSet<NhanVien> NhanViens { get; set; }
    public DbSet<PhuCapNhanVien> PhuCapNhanViens { get; set; }
    public DbSet<ChiNhanh> ChiNhanhs { get; set; }
    public DbSet<DanhGiaKpi> DanhGiaKpis { get; set; }
    public DbSet<KeHoachCongViec> KeHoachCongViecs { get; set; }
    public DbSet<MucTieuKpi> MucTieuKpis { get; set; }
    public DbSet<TienDoLamViec> TienDoLamViecs { get; set; }

    //Business
    public DbSet<SanPham> SanPhams { get; set; }
    public DbSet<LoaiHopDong> LoaiHopDongs { get; set; }
    public DbSet<HopDongNhanVien> HopDongNhanViens { get; set; }
    public DbSet<TienTe> TienTes { get; set; }
    public DbSet<ThuChi> ThuChis { get; set; }
    public DbSet<LoaiThuChi> LoaiThuChis { get; set; }
    public DbSet<TaiKhoanKeToan> TaiKhoanKeToans { get; set; }
    public DbSet<ThanhPho> ThanhPhos { get; set; }
    public DbSet<NhomSanPham> NhomSanPhams { get; set; }
    public DbSet<DonViTinh> DonViTinhs { get; set; }
    public DbSet<LoaiNhapXuat> LoaiNhapXuats { get; set; }
    public DbSet<PhieuNhapXuat> PhieuNhapXuats { get; set; }
    public DbSet<ChiTietPhieuNhapXuat> ChiTietPhieuNhapXuats { get; set; }
    public DbSet<KhoHang> KhoHangs { get; set; }
    public DbSet<KhachHang> KhachHangs { get; set; }
    public DbSet<LoaiKhachHang> LoaiKhachHangs { get; set; }
    public DbSet<DonHang> DonHangs { get; set; }
    public DbSet<LoaiDonHang> LoaiDonHangs { get; set; }
    public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
    public DbSet<BaoGia> BaoGias { get; set; }
    public DbSet<ChiTietBaoGia> ChiTietBaoGias { get; set; }

    #endregion

    public VietLifeDbContext(DbContextOptions<VietLifeDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Ignore<ExtraPropertyDictionary>();
        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */
       
        builder.ApplyConfiguration(new IdentitySettingConfiguration());

        builder.ApplyConfiguration(new NhanVienConfiguration());
        builder.ApplyConfiguration(new ChamCongConfiguration());
        builder.ApplyConfiguration(new PhongBanConfiguration());
        builder.ApplyConfiguration(new ChucVuConfiguration());
        builder.ApplyConfiguration(new LichLamViecConfiguration());
        builder.ApplyConfiguration(new LuongNhanVienConfiguration());
        builder.ApplyConfiguration(new KpiNhanVienConfiguration());
        builder.ApplyConfiguration(new CheDoNhanVienConfiguration());
        builder.ApplyConfiguration(new PhuCapNhanVienConfiguration());
        builder.ApplyConfiguration(new KeHoachCongViecConfiguration());
        builder.ApplyConfiguration(new MucTieuKpiConfiguration());
        builder.ApplyConfiguration(new TienDoLamViecConfiguration());
        builder.ApplyConfiguration(new DanhGiaKpiConfiguration());
        builder.ApplyConfiguration(new ChiNhanhConfiguration());
        builder.ApplyConfiguration(new LoaiCheDoConfiguration());

        //Business Configurations
        builder.ApplyConfiguration(new SanPhamConfiguration());
        builder.ApplyConfiguration(new ChiTietPhieuNhapXuatConfiguration());
        builder.ApplyConfiguration(new PhieuNhapXuatConfiguration());
        builder.ApplyConfiguration(new KhoHangConfiguration());
        builder.ApplyConfiguration(new KhachHangConfiguration());
        builder.ApplyConfiguration(new BaoGiaConfiguration());
        builder.ApplyConfiguration(new ChiTietBaoGiaConfiguration());
        builder.ApplyConfiguration(new DonHangConfiguration());
        builder.ApplyConfiguration(new ChiTietDonHangConfiguration());
        builder.ApplyConfiguration(new LoaiDonHangConfiguration());
        builder.ApplyConfiguration(new LoaiKhachHangConfiguration());
        builder.ApplyConfiguration(new TienTeConfiguration());
        builder.ApplyConfiguration(new HopDongNhanVienConfiguration());
        builder.ApplyConfiguration(new LoaiHopDongConfiguration());
        builder.ApplyConfiguration(new ThanhPhoConfiguration());
        builder.ApplyConfiguration(new NhomSanPhamConfiguration());
        builder.ApplyConfiguration(new DonViTinhConfiguration());
        builder.ApplyConfiguration(new LoaiNhapXuatConfiguration());
        builder.ApplyConfiguration(new ThuChiConfiguration());
        builder.ApplyConfiguration(new LoaiThuChiConfiguration());
        builder.ApplyConfiguration(new TaiKhoanKeToanConfiguration());

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(VietLifeConsts.DbTablePrefix + "YourEntities", VietLifeConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
