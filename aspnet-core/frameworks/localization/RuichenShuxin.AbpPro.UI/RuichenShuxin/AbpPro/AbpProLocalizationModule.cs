namespace RuichenShuxin.AbpPro.Localization;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpLocalizationModule),
    typeof(AbpProCoreModule)
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
                   .Add<AbpProLocalizationResource>(AbpProCoreConsts.Languages.ZhHans)
                   .AddVirtualJson("/RuichenShuxin/AbpPro/Localization/Resources");

            options.Resources
                   .Get<IdentityResource>()
                   .AddVirtualJson("/RuichenShuxin/AbpPro/Localization/Identity");

            options.Resources
                   .Add<AbpSaasResource>(AbpProCoreConsts.Languages.ZhHans)
                   .AddVirtualJson("/RuichenShuxin/AbpPro/Localization/Saas");

            options.Resources
                   .Get<AbpOpenIddictResource>()
                   .AddVirtualJson("/RuichenShuxin/AbpPro/Localization/OpenIddict");

            options.DefaultResourceType = typeof(AbpProLocalizationResource);

        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(AbpProLocalizationConsts.NameSpace, typeof(AbpProLocalizationResource));
        });

    }
}
