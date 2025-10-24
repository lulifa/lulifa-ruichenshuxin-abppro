using RuichenShuxin.AbpPro.Core;
using Volo.Abp.Identity.Settings;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace RuichenShuxin.AbpPro.Settings;

public class AbpProSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {

        DefineAbpProSettings(context);

        DefineLocalizationSettings(context);

        DefineIdentityPasswordPolicySettings(context);

    }

    private void DefineAbpProSettings(ISettingDefinitionContext context)
    {
        context.Add(new SettingDefinition(AbpProSettings.MySetting1,"lulifa123456"));
    }

    private void DefineLocalizationSettings(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(LocalizationSettingNames.DefaultLanguage,
                AbpProCoreConsts.Languages.ZhHans,
                L("DisplayName:Abp.Localization.DefaultLanguage"),
                L("Description:Abp.Localization.DefaultLanguage"),
                isVisibleToClients: true)
        );
    }

    private void DefineIdentityPasswordPolicySettings(ISettingDefinitionContext context)
    {
        // 修改密码策略
        var requireNonAlphanumeric = context.GetOrNull(IdentitySettingNames.Password.RequireNonAlphanumeric);
        if (requireNonAlphanumeric != null)
        {
            requireNonAlphanumeric.DefaultValue = false.ToString();
        }

        var requireLowercase = context.GetOrNull(IdentitySettingNames.Password.RequireLowercase);
        if (requireLowercase != null)
        {
            requireLowercase.DefaultValue = false.ToString();
        }

        var requireUppercase = context.GetOrNull(IdentitySettingNames.Password.RequireUppercase);
        if (requireUppercase != null)
        {
            requireUppercase.DefaultValue = false.ToString();
        }

        var requireDigit = context.GetOrNull(IdentitySettingNames.Password.RequireDigit);
        if (requireDigit != null)
        {
            requireDigit.DefaultValue = false.ToString();
        }
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpProResource>(name);
    }

}
