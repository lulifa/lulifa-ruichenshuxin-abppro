namespace RuichenShuxin.AbpPro.Core;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(AbpExceptionFilter))]
public class AbpProCoreExceptionFilter : AbpExceptionFilter, ITransientDependency
{
    protected override bool ShouldHandleException(ExceptionContext context)
    {
        return ShouldWrapResult(context) || base.ShouldHandleException(context);
    }

    protected override async Task HandleAndWrapException(ExceptionContext context)
    {
        if (await HandleWrapResultAsync(context)) return;

        await base.HandleAndWrapException(context);
    }

    private bool ShouldWrapResult(ExceptionContext context)
    {
        var controllerAction = context.ActionDescriptor.AsControllerActionDescriptor();
        if (controllerAction == null) return false;

        // 使用泛型方法，更简洁
        return controllerAction.ControllerTypeInfo.GetCustomAttributes<AbpProCoreWrapResultAttribute>(true).Any() ||
               controllerAction.MethodInfo.GetCustomAttributes<AbpProCoreWrapResultAttribute>(true).Any();
    }

    /// <summary>
    /// 如果开启 WrapResult 特性，则进行处理
    /// </summary>
    private async Task<bool> HandleWrapResultAsync(ExceptionContext context)
    {
        if (!ShouldWrapResult(context)) return false;

        // 执行异常通知
        await context.GetRequiredService<IExceptionNotifier>()
                     .NotifyAsync(new ExceptionNotificationContext(context.Exception));

        // 使用ABP的状态码查找器，保持与ABP一致的行为
        var statusCodeFinder = context.GetRequiredService<IHttpExceptionStatusCodeFinder>();
        var statusCode = (int)statusCodeFinder.GetStatusCode(context.HttpContext, context.Exception);

        // 设置响应
        context.HttpContext.Response.Headers[AbpProCoreConsts.AbpWrapResult] = "true";
        context.HttpContext.Response.StatusCode = statusCode;
        context.Result = new ObjectResult(CreateWrapResult(context));
        context.ExceptionHandled = true;

        return true;
    }

    /// <summary>
    /// 构建 WrapResult
    /// </summary>
    private AbpProCoreWrapResult<object> CreateWrapResult(ExceptionContext context)
    {
        var result = new AbpProCoreWrapResult<object>();
        var localizer = context.GetRequiredService<IStringLocalizer<AbpProUIResource>>();
        // 获取详细信息
        string details = context.Exception.ToString();

        switch (context.Exception)
        {
            case AbpAuthorizationException:
                result.SetFail(localizer[AbpProUIErrorCodes.ErrorCode100001], $"{(int)HttpStatusCode.Unauthorized}", details);
                break;
            case AbpValidationException validation:
                var errorMessage = localizer[AbpProUIErrorCodes.ErrorCode100002] + ";" + validation.ValidationErrors.JoinAsString(";");
                result.SetFail(errorMessage, $"{(int)HttpStatusCode.BadRequest}", details);
                break;
            case EntityNotFoundException:
                result.SetFail(localizer[AbpProUIErrorCodes.ErrorCode100003], $"{(int)HttpStatusCode.NotFound}", details);
                break;
            case NotImplementedException:
                result.SetFail(localizer[AbpProUIErrorCodes.ErrorCode100004], $"{(int)HttpStatusCode.NotImplemented}", details);
                break;
            case DbUpdateConcurrencyException:
                result.SetFail(localizer[AbpProUIErrorCodes.ErrorCode100005], $"{(int)HttpStatusCode.Conflict}", details);
                break;
            default:
                if (context.Exception is IHasErrorCode codeException)
                {
                    var exceptionConverter = context.GetRequiredService<IAbpProUIExceptionConverter>();
                    var message = exceptionConverter.TryToLocalizeExceptionMessage(context.Exception);

                    if (codeException.Code.IsNullOrWhiteSpace())
                        result.SetFail(message, $"{(int)HttpStatusCode.InternalServerError}", details);
                    else
                        result.SetFail(message, codeException.Code, details);
                }
                else
                {
                    result.SetFail(context.Exception.Message, $"{(int)HttpStatusCode.InternalServerError}", details);
                }
                break;
        }

        return result;
    }


}
