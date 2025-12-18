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
                .Add<AbpProResource>(AbpProCoreConsts.Languages.ZhHans)
                .AddVirtualJson("/RuichenShuxin/AbpPro/Localization/Resources");

            options.DefaultResourceType = typeof(AbpProResource);

        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("AbpPro", typeof(AbpProResource));
        });
    }
}
