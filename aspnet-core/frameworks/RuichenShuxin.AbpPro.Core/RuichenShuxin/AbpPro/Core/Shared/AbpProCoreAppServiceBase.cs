namespace RuichenShuxin.AbpPro.Core;

public abstract class AbpProCoreAppServiceBase<TResource, TModule> : ApplicationService
    where TResource : class
    where TModule : class
{
    protected AbpProCoreAppServiceBase()
    {
        LocalizationResource = typeof(TResource);
        ObjectMapperContext = typeof(TModule);
    }
}
