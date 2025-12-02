namespace RuichenShuxin.AbpPro.EntityFrameworkCore;

[DependsOn(
    typeof(AbpProDomainModule),

    typeof(PlatformEntityFrameworkCoreModule),

    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
    )]
public class AbpProEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {

        AbpProEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AbpProDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);

            options.AddRepository<IdentityRole, EfCoreIdentityRoleRepository>();
            options.AddRepository<IdentityUser, EfCoreIdentityUserRepository>();
            options.AddRepository<OrganizationUnit, EfCoreOrganizationUnitRepository>();

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
