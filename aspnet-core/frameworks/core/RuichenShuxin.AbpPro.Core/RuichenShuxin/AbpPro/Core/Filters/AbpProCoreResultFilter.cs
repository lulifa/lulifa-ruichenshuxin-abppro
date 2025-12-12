namespace RuichenShuxin.AbpPro.Core;

public class AbpProCoreResultFilter : IResultFilter, ITransientDependency
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.HttpContext.Response.Headers.ContainsKey(AbpProCoreConsts.AbpWrapResult))
            return;

        if (context.ActionDescriptor.IsPageAction()) return;

        var controllerActionDescriptor = context.ActionDescriptor.AsControllerActionDescriptor();
        if (controllerActionDescriptor == null) return;

        var controllerHasWrap = controllerActionDescriptor.ControllerTypeInfo
            .GetCustomAttributes(typeof(AbpProCoreWrapResultAttribute), true).Any();
        var actionHasWrap = controllerActionDescriptor.MethodInfo
            .GetCustomAttributes(typeof(AbpProCoreWrapResultAttribute), true).Any();

        if (!controllerHasWrap && !actionHasWrap) return;

        context.HttpContext.Response.Headers[AbpProCoreConsts.AbpWrapResult] = "true";

        var (originalValue, statusCode) = GetOriginalValueAndStatusCode(context.Result);

        if (statusCode >= 400) return;

        var wrapResult = new AbpProCoreWrapResult<object>();
        wrapResult.SetSuccess(originalValue);

        var jsonSerializer = context.GetRequiredService<IJsonSerializer>();

        context.Result = new ContentResult
        {
            StatusCode = statusCode, // 使用原始状态码
            ContentType = "application/json;charset=utf-8",
            Content = jsonSerializer.Serialize(wrapResult)
        };
    }

    public void OnResultExecuted(ResultExecutedContext context) { }

    private (object value, int statusCode) GetOriginalValueAndStatusCode(IActionResult result)
    {
        int okStatusCode = (int)HttpStatusCode.OK;
        return result switch
        {
            ObjectResult objectResult => (objectResult.Value, objectResult.StatusCode ?? okStatusCode),
            JsonResult jsonResult => (jsonResult.Value, jsonResult.StatusCode ?? okStatusCode),
            ContentResult contentResult => (contentResult.Content, contentResult.StatusCode ?? okStatusCode),
            StatusCodeResult statusCodeResult => (null, statusCodeResult.StatusCode),
            EmptyResult => (null, okStatusCode),
            _ => (null, okStatusCode)
        };
    }
}
