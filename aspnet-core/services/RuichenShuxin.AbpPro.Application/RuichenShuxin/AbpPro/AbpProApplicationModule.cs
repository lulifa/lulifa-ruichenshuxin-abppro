namespace RuichenShuxin.AbpPro;

[DependsOn(
    typeof(AbpProDomainModule),
    typeof(AbpProApplicationContractsModule),

    typeof(PlatformApplicationModule),

    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class AbpProApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AbpProApplicationModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AbpProApplicationModule>();
        });
    }
}
