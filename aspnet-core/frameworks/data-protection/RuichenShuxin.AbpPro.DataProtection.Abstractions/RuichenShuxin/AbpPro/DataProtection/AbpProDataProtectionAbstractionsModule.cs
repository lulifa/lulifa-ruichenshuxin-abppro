namespace RuichenShuxin.AbpPro.DataProtection.Abstractions;

[DependsOn(typeof(AbpLocalizationModule))]
[DependsOn(typeof(AbpMultiTenancyModule))]
[DependsOn(typeof(AbpObjectExtendingModule))]
public class AbpProDataProtectionAbstractionsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton<ICurrentDataAccessAccessor>(AsyncLocalCurrentDataAccessAccessor.Instance);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpProDataProtectionAbstractionsModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<DataProtectionResource>()
                .AddVirtualJson("/RuiChen/Abp/DataProtection/Localization/Resources");
        });
    }
}
