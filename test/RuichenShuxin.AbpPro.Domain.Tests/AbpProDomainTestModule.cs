using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro;

[DependsOn(
    typeof(AbpProDomainModule),
    typeof(AbpProTestBaseModule)
)]
public class AbpProDomainTestModule : AbpModule
{

}
