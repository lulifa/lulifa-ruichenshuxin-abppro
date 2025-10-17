using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpProDomainTestBase<TStartupModule> : AbpProTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
