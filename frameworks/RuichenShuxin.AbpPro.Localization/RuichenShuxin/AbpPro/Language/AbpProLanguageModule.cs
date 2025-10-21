namespace RuichenShuxin.AbpPro.Language;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpLocalizationModule)
    )]
public class AbpProLanguageModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AbpProLanguageModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                   .Add<AbpProLanguageResource>(AbpProLanguageConsts.DefaultCultureName)
                   .AddVirtualJson(AbpProLanguageConsts.DefaultLocalizationResourceVirtualPath);

            options.DefaultResourceType = typeof(AbpProLanguageResource);

        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(AbpProLanguageConsts.NameSpace, typeof(AbpProLanguageResource));
        });

    }
}
