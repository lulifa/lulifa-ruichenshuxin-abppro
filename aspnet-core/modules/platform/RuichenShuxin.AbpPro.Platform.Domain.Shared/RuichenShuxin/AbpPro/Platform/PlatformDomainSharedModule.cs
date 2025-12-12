namespace RuichenShuxin.AbpPro.Platform;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpDddDomainSharedModule),
    typeof(AbpProCoreModule)
)]
public class PlatformDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PlatformDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<PlatformResource>(AbpProLocalizationConsts.DefaultCultureName)
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/RuichenShuxin/AbpPro/Platform/Localization/Resources");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(PlatformErrorCodes.Namespace, typeof(PlatformResource));
        });
    }
}
