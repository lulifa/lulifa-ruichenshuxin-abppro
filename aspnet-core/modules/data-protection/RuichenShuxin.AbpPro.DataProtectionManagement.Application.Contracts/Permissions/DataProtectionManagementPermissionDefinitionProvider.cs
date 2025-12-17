using RuichenShuxin.AbpPro.DataProtectionManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RuichenShuxin.AbpPro.DataProtectionManagement.Permissions;

public class DataProtectionManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DataProtectionManagementPermissions.GroupName, L("Permission:DataProtectionManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DataProtectionManagementResource>(name);
    }
}
