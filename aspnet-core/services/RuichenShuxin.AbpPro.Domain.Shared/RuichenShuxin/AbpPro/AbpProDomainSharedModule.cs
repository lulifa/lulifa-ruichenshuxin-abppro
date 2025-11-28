namespace RuichenShuxin.AbpPro;

[DependsOn(
    typeof(PlatformDomainSharedModule),

    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpTenantManagementDomainSharedModule),
    typeof(BlobStoringDatabaseDomainSharedModule),
    typeof(AbpProCoreModule)
    )]
public class AbpProDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AbpProGlobalFeatureConfigurator.Configure();
        AbpProModuleExtensionConfigurator.Configure();
    }

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
            options.MapCodeNamespace(SystemTenantErrorCodes.Namespace, typeof(AbpProResource));
        });
    }
}
