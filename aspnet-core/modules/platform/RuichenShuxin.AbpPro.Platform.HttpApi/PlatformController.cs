using Volo.Abp.AspNetCore.Mvc;

namespace RuichenShuxin.AbpPro.Platform;

public abstract class PlatformController : AbpControllerBase
{
    protected PlatformController()
    {
        LocalizationResource = typeof(PlatformResource);
    }
}
