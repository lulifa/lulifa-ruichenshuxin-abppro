using Microsoft.Extensions.DependencyInjection;
using RuichenShuxin.AbpPro.Localization;
using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro.Core;

[DependsOn(
    typeof(AbpProLocalizationModule)
    )]
public class AbpProCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<AppOptions>(options =>
        {
            configuration.BindOptions(options);
        });

        Configure<ExternalOAuthOptions>(options =>
        {
            configuration.BindOptions(options);
        });

        Configure<AuthServerOptions>(options =>
        {
            configuration.BindOptions(options);
        });

        Configure<MultiTenancyOptions>(options =>
        {
            configuration.BindOptions(options);
        });

        var test=configuration.GetOptions<ExternalOAuthOptions>();

    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
    }

}
