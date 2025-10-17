using RuichenShuxin.AbpPro.Language.Localization;
using Volo.Abp.Application.Services;

namespace RuichenShuxin.AbpPro.Language;

public abstract class LanguageAppService : ApplicationService
{
    protected LanguageAppService()
    {
        LocalizationResource = typeof(LanguageResource);
        ObjectMapperContext = typeof(LanguageApplicationModule);
    }
}
