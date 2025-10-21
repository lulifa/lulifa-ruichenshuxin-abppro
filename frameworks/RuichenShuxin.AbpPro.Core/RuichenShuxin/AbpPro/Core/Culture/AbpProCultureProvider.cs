using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Threading.Tasks;

namespace RuichenShuxin.AbpPro.Core;

public class AbpProCultureProvider : AcceptLanguageHeaderRequestCultureProvider
{
    public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    {
        return base.DetermineProviderCultureResult(httpContext);
    }
}
