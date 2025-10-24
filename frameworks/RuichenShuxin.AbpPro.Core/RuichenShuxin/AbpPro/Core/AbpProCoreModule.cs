namespace RuichenShuxin.AbpPro.Core;

[DependsOn(
    typeof(AbpProLocalizationModule)
    )]
public class AbpProCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        context.Services.ConfigureOptions<AppOptions>()
                        .ConfigureOptions<AuthServerOptions>()
                        .ConfigureOptions<MultiTenancyOptions>();

    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
    }

}
