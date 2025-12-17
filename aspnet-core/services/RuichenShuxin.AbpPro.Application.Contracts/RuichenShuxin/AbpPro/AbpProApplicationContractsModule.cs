namespace RuichenShuxin.AbpPro;

[DependsOn(
    typeof(AbpProDomainSharedModule),

    typeof(DataProtectionManagementApplicationContractsModule),
    typeof(PlatformApplicationContractsModule),

    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule)
)]
public class AbpProApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AbpProDtoExtensions.Configure();
    }
}
