using RuichenShuxin.AbpPro.Platform.Localization;
using Volo.Abp.Application.Services;

namespace RuichenShuxin.AbpPro.Platform;

public abstract class PlatformAppService : ApplicationService
{
    protected PlatformAppService()
    {
        LocalizationResource = typeof(PlatformResource);
        ObjectMapperContext = typeof(PlatformApplicationModule);
    }
}
