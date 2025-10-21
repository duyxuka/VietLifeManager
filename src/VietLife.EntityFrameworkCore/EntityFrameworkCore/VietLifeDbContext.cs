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
using VietLife.Inventories;
using VietLife.InventoryTickets;
using VietLife.Manufacturers;
using VietLife.Orders;
using VietLife.Products;
using VietLife.ProductCategories;
using VietLife.Promotions;
using VietLife.IdentitySettings;
using VietLife.ProductAttributes;
using VietLife.ChamCongs;
using VietLife.Chucvus;
using VietLife.KPINhanViens;
using VietLife.LichLamViecs;
using VietLife.LuongNhanViens;
using VietLife.PhongBans;
using VietLife.CheDoNhanViens;
using VietLife.Configurations.ChamCongs;
using VietLife.Configurations.ChucVus;
using VietLife.Configurations.KpiNhanViens;
using VietLife.Configurations.LichLamViecs;
using VietLife.Configurations.LuongNhanViens;
using VietLife.Configurations.PhongBans;
using VietLife.Configurations.Users;
using VietLife.NhanViens;
using VietLife.PhuCapNhanViens;
using VietLife.Configurations.CheDoNhanViens;
using VietLife.Configurations.PhuCapNhanViens;
using VietLife.ChiNhanhs;
using System.Reflection.Emit;
using VietLife.Configurations.ChiNhanhs;

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
    public DbSet<ProductAttribute> ProductAttributes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryTicket> InventoryTickets { get; set; }
    public DbSet<InventoryTicketItem> InventoryTicketItems { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderTransaction> OrderTransactions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductAttributeDateTime> ProductAttributeDateTimes { get; set; }
    public DbSet<ProductAttributeDecimal> ProductAttributeDecimals { get; set; }
    public DbSet<ProductAttributeInt> ProductAttributeInts { get; set; }
    public DbSet<ProductAttributeVarchar> ProductAttributeVarchars { get; set; }
    public DbSet<ProductAttributeText> ProductAttributeTexts { get; set; }
    public DbSet<ProductLink> ProductLinks { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionCategory> PromotionCategories { get; set; }
    public DbSet<PromotionManufacturer> PromotionManufacturers { get; set; }
    public DbSet<PromotionProduct> PromotionProducts { get; set; }
    public DbSet<PromotionUsageHistory> PromotionUsageHistories { get; set; }
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
        builder.ApplyConfiguration(new ProductAttributeConfiguration());

        builder.ApplyConfiguration(new InventoryConfiguration());

        builder.ApplyConfiguration(new InventoryTicketConfiguration());
        builder.ApplyConfiguration(new InventoryTicketItemConfiguration());

        builder.ApplyConfiguration(new ManufacturerConfiguration());

        builder.ApplyConfiguration(new OrderConfiguration());
        builder.ApplyConfiguration(new OrderItemConfiguration());
        builder.ApplyConfiguration(new OrderTransactionConfiguration());

        builder.ApplyConfiguration(new ProductCategoryConfiguration());

        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new ProductLinkConfiguration());
        builder.ApplyConfiguration(new ProductReviewConfiguration());
        builder.ApplyConfiguration(new ProductTagConfiguration());
        builder.ApplyConfiguration(new TagConfiguration());
        builder.ApplyConfiguration(new ProductAttributeDateTimeConfiguration());
        builder.ApplyConfiguration(new ProductAttributeDecimalConfiguration());
        builder.ApplyConfiguration(new ProductAttributeIntConfiguration());
        builder.ApplyConfiguration(new ProductAttributeTextConfiguration());
        builder.ApplyConfiguration(new ProductAttributeVarcharConfiguration());

        builder.ApplyConfiguration(new PromotionConfiguration());
        builder.ApplyConfiguration(new PromotionCategoryConfiguration());
        builder.ApplyConfiguration(new PromotionManufacturerConfiguration());
        builder.ApplyConfiguration(new PromotionProductConfiguration());
        builder.ApplyConfiguration(new PromotionUsageHistoryConfiguration());
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

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(VietLifeConsts.DbTablePrefix + "YourEntities", VietLifeConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
