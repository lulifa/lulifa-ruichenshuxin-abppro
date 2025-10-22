using Microsoft.Extensions.DependencyInjection;
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
        var configuration = context.Services.GetConfiguration();

        PreConfigure<AppOptions>(options =>
        {
            configuration.BindOptions(options);
        });

        PreConfigure<AuthServerOptions>(options =>
        {
            configuration.BindOptions(options);
        });

        PreConfigure<MultiTenancyOptions>(options =>
        {
            configuration.BindOptions(options);
        });

    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
    }

}
