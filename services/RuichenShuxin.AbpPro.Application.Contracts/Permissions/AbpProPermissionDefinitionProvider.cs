using RuichenShuxin.AbpPro.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace RuichenShuxin.AbpPro.Permissions;

public class AbpProPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpProPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(AbpProPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AbpProPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AbpProPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AbpProPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpProPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpProResource>(name);
    }
}
