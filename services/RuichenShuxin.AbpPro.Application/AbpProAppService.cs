using RuichenShuxin.AbpPro.Localization;
using Volo.Abp.Application.Services;

namespace RuichenShuxin.AbpPro;

/* Inherit your application services from this class.
 */
public abstract class AbpProAppService : ApplicationService
{
    protected AbpProAppService()
    {
        LocalizationResource = typeof(AbpProResource);
    }
}
