namespace RuichenShuxin.AbpPro.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpProEntityFrameworkCoreModule),
    typeof(AbpProApplicationContractsModule)
)]
public class AbpProDbMigratorModule : AbpModule
{
}
