using VietLife.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace VietLife.Permissions;

public class VietLifePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {

        //Catalog
        var catalogGroup = context.AddGroup(VietLifePermissions.CatalogGroupName, L("Permission:Catalog"));

        //Manufacture
        var manufacturerPermission = catalogGroup.AddPermission(VietLifePermissions.Manufacturer.Default, L("Permission:Catalog.Manufacturer"));
        manufacturerPermission.AddChild(VietLifePermissions.Manufacturer.Create, L("Permission:Catalog.Manufacturer.Create"));
        manufacturerPermission.AddChild(VietLifePermissions.Manufacturer.Update, L("Permission:Catalog.Manufacturer.Update"));
        manufacturerPermission.AddChild(VietLifePermissions.Manufacturer.Delete, L("Permission:Catalog.Manufacturer.Delete"));

        //Product Category
        var productCategoryPermission = catalogGroup.AddPermission(VietLifePermissions.ProductCategory.Default, L("Permission:Catalog.ProductCategory"));
        productCategoryPermission.AddChild(VietLifePermissions.ProductCategory.Create, L("Permission:Catalog.ProductCategory.Create"));
        productCategoryPermission.AddChild(VietLifePermissions.ProductCategory.Update, L("Permission:Catalog.ProductCategory.Update"));
        productCategoryPermission.AddChild(VietLifePermissions.ProductCategory.Delete, L("Permission:Catalog.ProductCategory.Delete"));

        //Product
        var productPermission = catalogGroup.AddPermission(VietLifePermissions.Product.Default, L("Permission:Catalog.Product"));
        productPermission.AddChild(VietLifePermissions.Product.Create, L("Permission:Catalog.Product.Create"));
        productPermission.AddChild(VietLifePermissions.Product.Update, L("Permission:Catalog.Product.Update"));
        productPermission.AddChild(VietLifePermissions.Product.Delete, L("Permission:Catalog.Product.Delete"));
        productPermission.AddChild(VietLifePermissions.Product.AttributeManage, L("Permission:Catalog.Product.AttributeManage"));

        //Attribute
        var attributePermission = catalogGroup.AddPermission(VietLifePermissions.Attribute.Default, L("Permission:Catalog.Attribute"));
        attributePermission.AddChild(VietLifePermissions.Attribute.Create, L("Permission:Catalog.Attribute.Create"));
        attributePermission.AddChild(VietLifePermissions.Attribute.Update, L("Permission:Catalog.Attribute.Update"));
        attributePermission.AddChild(VietLifePermissions.Attribute.Delete, L("Permission:Catalog.Attribute.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<VietLifeResource>(name);
    }
}
