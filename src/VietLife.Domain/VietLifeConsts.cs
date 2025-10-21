using Volo.Abp.Identity;

namespace VietLife;

public static class VietLifeConsts
{
    public const string DbTablePrefix = "App";
    public const string DbSchema = null;
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
    public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
    public const string ProductIdentitySettingId = "Product";

    public const string ProductIdentitySettingPrefix = "P";
    public const string Cart = "Cart";

    public const string OrderIdentitySettingId = "Order";

    public const string OrderIdentitySettingPrefix = "O";
}
