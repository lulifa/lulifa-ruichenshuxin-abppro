namespace RuichenShuxin.AbpPro;

[DependsOn(
     typeof(AbpAutoMapperModule),
     typeof(AbpDddDomainModule),
     typeof(AbpProDomainSharedModule))]
public class AbpProDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources.Get<AbpProResource>()
                .AddBaseTypes(typeof(DataProtectionResource));
        });

        Configure<AbpProDataProtectionOptions>(options =>
        {
            // 外键属性不可设定规则
            options.EntityIgnoreProperties.Add(typeof(Book), [nameof(Book.AuthorId)]);
        });
    }
}
