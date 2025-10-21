using RuichenShuxin.AbpPro.Localization;
using RuichenShuxin.AbpPro.OAuth;
using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro.Core;

[DependsOn(
    typeof(AbpProOAuthModule),
    typeof(AbpProLocalizationModule)
    )]
public class AbpProCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        base.PreConfigureServices(context);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
    }

}
