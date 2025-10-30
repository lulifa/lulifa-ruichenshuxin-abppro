namespace RuichenShuxin.AbpPro.Core;

public class AbpProCoreResultFilter : IResultFilter, ITransientDependency
{
    // 定义需要强制 Wrap 的 ABP 系统接口路径（可扩展到配置文件）
    private static readonly string[] WrapRoutePrefixes =
    {
        //"/connect/token",                         // OpenIddict 登录
        //"/api/abp/application-configuration",     // ABP 应用配置
        //"/api/abp/features",                      // Feature 管理
        //"/api/abp/permissions"                    // 权限配置
    };

    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.ActionDescriptor.IsPageAction()) return;

        var controllerActionDescriptor = context.ActionDescriptor.AsControllerActionDescriptor();

        if (controllerActionDescriptor == null) return;

        //  路由白名单匹配（忽略大小写）
        var path = context.HttpContext.Request.Path.Value?.ToLowerInvariant();

        var isMatchRoute = !string.IsNullOrWhiteSpace(path) &&
                           WrapRoutePrefixes.Any(p => path.StartsWith(p, StringComparison.OrdinalIgnoreCase));



        var controllerHasWrap = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(AbpProCoreWrapResultAttribute), true).Any();

        var actionHasWrap = context.ActionDescriptor.GetMethodInfo().GetCustomAttributes(typeof(AbpProCoreWrapResultAttribute), true).Any();

        // 没有 Wrap 特性 且 不在白名单路由中 → 不处理
        if (!controllerHasWrap && !actionHasWrap && !isMatchRoute) return;

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
