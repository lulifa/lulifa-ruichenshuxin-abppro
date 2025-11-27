using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RuichenShuxin.AbpPro.Platform.Permissions;

public class PlatformPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(PlatformPermissions.GroupName, L("Permission:Platform"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<PlatformResource>(name);
    }
}
