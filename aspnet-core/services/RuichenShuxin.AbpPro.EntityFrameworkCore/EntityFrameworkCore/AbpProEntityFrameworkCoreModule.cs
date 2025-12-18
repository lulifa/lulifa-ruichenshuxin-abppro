namespace RuichenShuxin.AbpPro.EntityFrameworkCore;

[DependsOn(
    typeof(AbpProDomainModule),
    typeof(DataProtectionManagementEntityFrameworkCoreModule),
    typeof(PlatformEntityFrameworkCoreModule),
    typeof(AbpProDataProtectionEntityFrameworkCoreModule))]
public class AbpProEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AbpProDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);

        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL(builder =>
            {
                builder.TranslateParameterizedCollectionsToConstants()
                       .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

        });

    }
}
