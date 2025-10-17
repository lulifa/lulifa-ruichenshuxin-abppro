using RuichenShuxin.AbpPro.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace RuichenShuxin.AbpPro.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpProController : AbpControllerBase
{
    protected AbpProController()
    {
        LocalizationResource = typeof(AbpProResource);
    }
}
