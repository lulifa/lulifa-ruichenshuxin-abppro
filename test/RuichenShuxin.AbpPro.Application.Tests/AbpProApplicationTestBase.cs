using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro;

public abstract class AbpProApplicationTestBase<TStartupModule> : AbpProTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
