using RuichenShuxin.AbpPro.Language.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace RuichenShuxin.AbpPro.Language;

public abstract class LanguageController : AbpControllerBase
{
    protected LanguageController()
    {
        LocalizationResource = typeof(LanguageResource);
    }
}
