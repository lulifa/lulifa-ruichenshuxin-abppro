using Microsoft.AspNetCore.Mvc.Filters;
using Volo.Abp.DependencyInjection;

namespace RuichenShuxin.AbpPro.Core;

public class AbpProResultFilter : IResultFilter, ITransientDependency
{
    public void OnResultExecuted(ResultExecutedContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        throw new System.NotImplementedException();
    }
}
