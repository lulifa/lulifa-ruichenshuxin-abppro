using Volo.Abp.OpenIddict.Localization;

namespace RuichenShuxin.AbpPro.UI;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpLocalizationModule)
    )]
public class AbpProUIModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpProUIModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                   .Add<AbpProUIResource>(AbpProUIConsts.DefaultCultureName)
                   .AddVirtualJson("/RuichenShuxin/AbpPro/UI/Localization/Resources");

            options.Resources
                   .Get<IdentityResource>()
                   .AddVirtualJson("/RuichenShuxin/AbpPro/UI/Localization/Identity");

            options.Resources
                   .Add<AbpSaasResource>(AbpProUIConsts.DefaultCultureName)
                   .AddVirtualJson("/RuichenShuxin/AbpPro/UI/Localization/Saas");

            options.Resources
                   .Get<AbpOpenIddictResource>()
                   .AddVirtualJson("/RuichenShuxin/AbpPro/UI/Localization/OpenIddict");

            options.DefaultResourceType = typeof(AbpProUIResource);

        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(AbpProUIConsts.NameSpace, typeof(AbpProUIResource));
        });

    }
}
