using Volo.Abp.OpenIddict.Localization;

namespace RuichenShuxin.AbpPro.Localization;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpLocalizationModule)
    )]
public class AbpProLocalizationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpProLocalizationModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                   .Add<AbpProLocalizationResource>(AbpProLocalizationConsts.DefaultCultureName)
                   .AddVirtualJson("/RuichenShuxin/AbpPro/UI/Localization/Resources");

            options.Resources
                   .Get<IdentityResource>()
                   .AddVirtualJson("/RuichenShuxin/AbpPro/UI/Localization/Identity");

            options.Resources
                   .Add<AbpSaasResource>(AbpProLocalizationConsts.DefaultCultureName)
                   .AddVirtualJson("/RuichenShuxin/AbpPro/UI/Localization/Saas");

            options.Resources
                   .Get<AbpOpenIddictResource>()
                   .AddVirtualJson("/RuichenShuxin/AbpPro/UI/Localization/OpenIddict");

            options.DefaultResourceType = typeof(AbpProLocalizationResource);

        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(AbpProLocalizationConsts.NameSpace, typeof(AbpProLocalizationResource));
        });

    }
}
