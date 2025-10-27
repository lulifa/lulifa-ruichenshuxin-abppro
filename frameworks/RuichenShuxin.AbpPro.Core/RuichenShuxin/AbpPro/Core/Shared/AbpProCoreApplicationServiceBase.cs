namespace RuichenShuxin.AbpPro.Core;

public abstract class AbpProCoreApplicationServiceBase<TResource, TModule> : ApplicationService
    where TResource : class
    where TModule : class
{
    protected AbpProCoreApplicationServiceBase()
    {
        LocalizationResource = typeof(TResource);
        ObjectMapperContext = typeof(TModule);
    }
}
