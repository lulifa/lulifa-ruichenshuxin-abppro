using RuichenShuxin.AbpPro.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpProEntityFrameworkCoreModule),
    typeof(AbpProApplicationContractsModule)
)]
public class AbpProDbMigratorModule : AbpModule
{
}
