namespace RuichenShuxin.AbpPro.Platform;

[DependsOn(
    typeof(PlatformDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class PlatformEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<PlatformDbContext>(options =>
        {
            options.AddDefaultRepositories<IPlatformDbContext>(includeAllEntities: true);

            options.AddRepository<Menu, EfCoreMenuRepository>();
            options.AddRepository<UserMenu, EfCoreUserMenuRepository>();
            options.AddRepository<RoleMenu, EfCoreRoleMenuRepository>();
            options.AddRepository<UserFavoriteMenu, EfCoreUserFavoriteMenuRepository>();

            options.AddRepository<Layout, EfCoreLayoutRepository>();

            options.AddRepository<Data, EfCoreDataRepository>();

        });
    }
}
