namespace RuichenShuxin.AbpPro;

[DependsOn(
    typeof(AbpDddDomainSharedModule))]
public class AbpProDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpProDomainSharedModule>("RuichenShuxin.AbpPro");
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpProResource>(AbpProCoreConsts.Languages.ZhHans)
                .AddVirtualJson("/RuichenShuxin/AbpPro/Localization/Resources");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("AbpPro", typeof(AbpProResource));
        });
    }
}
