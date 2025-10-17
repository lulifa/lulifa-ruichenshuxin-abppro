using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro;

[DependsOn(
    typeof(AbpProApplicationModule),
    typeof(AbpProDomainTestModule)
)]
public class AbpProApplicationTestModule : AbpModule
{

}
