namespace RuichenShuxin.AbpPro;

 [DependsOn(
    typeof(AbpProApplicationContractsModule),

    typeof(PlatformHttpApiModule),

    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule)
    )]
public class AbpProHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AbpProResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
