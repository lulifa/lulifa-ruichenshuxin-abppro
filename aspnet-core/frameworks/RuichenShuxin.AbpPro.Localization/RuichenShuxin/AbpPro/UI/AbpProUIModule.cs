namespace RuichenShuxin.AbpPro.UI;

[DependsOn(
    typeof(AbpAutofacModule),
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
                   .AddVirtualJson(AbpProUIConsts.DefaultLocalizationResourceVirtualPath);

            options.DefaultResourceType = typeof(AbpProUIResource);

        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace(AbpProUIConsts.NameSpace, typeof(AbpProUIResource));
        });

    }
}
