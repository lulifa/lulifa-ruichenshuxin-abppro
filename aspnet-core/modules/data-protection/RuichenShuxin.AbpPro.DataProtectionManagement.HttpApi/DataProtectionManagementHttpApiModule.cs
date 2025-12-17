using Localization.Resources.AbpUi;
using RuichenShuxin.AbpPro.DataProtectionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace RuichenShuxin.AbpPro.DataProtectionManagement;

[DependsOn(
    typeof(DataProtectionManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class DataProtectionManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(DataProtectionManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<DataProtectionManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
