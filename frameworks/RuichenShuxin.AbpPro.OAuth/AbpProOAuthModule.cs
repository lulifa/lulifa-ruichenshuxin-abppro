using Volo.Abp.Account.Web;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;

namespace RuichenShuxin.AbpPro.OAuth;

[DependsOn(
    typeof(AbpFeaturesModule),
    typeof(AbpSettingsModule))]
public class AbpProOAuthModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpProOAuthModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpProOAuthResource>()
                .AddVirtualJson("/Localization/Resources");
        });

        context.Services.AddOAuthProviders();
    }
}
