namespace RuichenShuxin.AbpPro.Core;

public class AbpProCoreResultFilter : IResultFilter, ITransientDependency
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.ActionDescriptor.IsPageAction()) return;

        var controllerActionDescriptor = context.ActionDescriptor.AsControllerActionDescriptor();

        if (controllerActionDescriptor == null) return;

        var controllerHasWrap = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(AbpProCoreWrapResultAttribute), true).Any();

        var actionHasWrap = context.ActionDescriptor.GetMethodInfo().GetCustomAttributes(typeof(AbpProCoreWrapResultAttribute), true).Any();

        // 没有 Wrap 特性  → 不处理
        if (!controllerHasWrap && !actionHasWrap) return;

        // 设置Wrap标识Header
        context.HttpContext.Response.Headers[AbpProCoreConsts.AbpWrapResult] = "true";

        object originalValue = context.Result switch
        {
            ObjectResult objectResult => objectResult.Value,
            EmptyResult => null,
            ContentResult contentResult => contentResult.Content,
            JsonResult jsonResult => jsonResult.Value,
            _ => null,
        };

        var wrapResult = new AbpProCoreWrapResult<object>();

        wrapResult.SetSuccess(originalValue);

        var jsonSerializer = context.GetRequiredService<IJsonSerializer>();

        context.Result = new ContentResult
        {
            StatusCode = (int)HttpStatusCode.OK,

            ContentType = "application/json;charset=utf-8",

            Content = jsonSerializer.Serialize(wrapResult)

        };

    }

    public void OnResultExecuted(ResultExecutedContext context) { }
}
