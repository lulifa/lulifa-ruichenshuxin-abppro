namespace RuichenShuxin.AbpPro.Platform;

[DependsOn(
    typeof(PlatformApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class PlatformHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(PlatformHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<PlatformResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
