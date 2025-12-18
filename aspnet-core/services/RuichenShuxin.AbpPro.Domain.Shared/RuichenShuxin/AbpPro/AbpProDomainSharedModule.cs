namespace RuichenShuxin.AbpPro;

[DependsOn(
    typeof(AbpDddDomainSharedModule))]
public class AbpProDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpProDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpProResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/RuichenShuxin/AbpPro/Localization/Resources");

            options.DefaultResourceType = typeof(AbpProResource);

        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("AbpPro", typeof(AbpProResource));
        });
    }
}
