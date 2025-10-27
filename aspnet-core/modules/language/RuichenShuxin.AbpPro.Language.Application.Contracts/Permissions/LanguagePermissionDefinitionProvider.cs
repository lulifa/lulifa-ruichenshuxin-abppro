using RuichenShuxin.AbpPro.Language.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RuichenShuxin.AbpPro.Language.Permissions;

public class LanguagePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LanguagePermissions.GroupName, L("Permission:Language"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LanguageResource>(name);
    }
}
