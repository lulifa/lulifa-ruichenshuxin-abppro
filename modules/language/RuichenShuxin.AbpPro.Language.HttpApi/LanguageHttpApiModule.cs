using Localization.Resources.AbpUi;
using RuichenShuxin.AbpPro.Language.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace RuichenShuxin.AbpPro.Language;

[DependsOn(
    typeof(LanguageApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class LanguageHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(LanguageHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<LanguageResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
