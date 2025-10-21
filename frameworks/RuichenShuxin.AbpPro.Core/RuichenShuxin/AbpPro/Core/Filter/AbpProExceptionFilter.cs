using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.DependencyInjection;

namespace RuichenShuxin.AbpPro.Core;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(AbpExceptionFilter))]
public class AbpProExceptionFilter : AbpExceptionFilter
{
}
