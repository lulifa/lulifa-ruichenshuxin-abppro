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
            options.AddRepository<Author, EfCoreAuthorRepository>();
            options.AddRepository<Book, EfCoreBookRepository>();

            options.AddDefaultRepositories();

        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseMySQL(builder =>
            {
                builder.TranslateParameterizedCollectionsToConstants()
                       .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            });

        });


        Configure<DataProtectionManagementOptions>(options =>
        {
            options.AddEntities(typeof(AbpProResource),
            [
                typeof(Book),
            ]);
        });

    }
}
