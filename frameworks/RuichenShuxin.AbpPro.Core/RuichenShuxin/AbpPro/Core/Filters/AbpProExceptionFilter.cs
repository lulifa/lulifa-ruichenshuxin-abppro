namespace RuichenShuxin.AbpPro.Core;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(AbpExceptionFilter))]
public class AbpProExceptionFilter : AbpExceptionFilter
{
    protected override bool ShouldHandleException(ExceptionContext context)
    {
        return ShouldWrapResult(context) || base.ShouldHandleException(context);
    }

    protected override async Task HandleAndWrapException(ExceptionContext context)
    {
        var logger = context.GetService<ILogger<AbpExceptionFilter>>(NullLogger<AbpExceptionFilter>.Instance)!;

        var logLevel = context.Exception.GetLogLevel();

        logger.LogException(context.Exception, logLevel);

        if (HandleWrapResult(context)) return;

        await HandleDefaultExceptionAsync(context);
    }

    /// <summary>
    /// 如果开启 WrapResult 特性，则进行处理
    /// </summary>
    private bool HandleWrapResult(ExceptionContext context)
    {
        if (!ShouldWrapResult(context)) return false;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;

        context.Result = new ObjectResult(CreateWrapResult(context));

        return true;
    }

    private async Task HandleDefaultExceptionAsync(ExceptionContext context)
    {
        var options = context.GetRequiredService<IOptions<AbpExceptionHandlingOptions>>().Value;

        var converter = context.GetRequiredService<IExceptionToErrorInfoConverter>();

        var remoteError = converter.Convert(context.Exception, opt =>
        {
            opt.SendExceptionsDetailsToClients = options.SendExceptionsDetailsToClients;
            opt.SendStackTraceToClients = options.SendStackTraceToClients;
        });

        if (context.Exception is AbpAuthorizationException)
        {
            await context.HttpContext.RequestServices
                .GetRequiredService<IAbpAuthorizationExceptionHandler>()
                .HandleAsync(context.Exception.As<AbpAuthorizationException>(), context.HttpContext);
        }
        else
        {
            context.HttpContext.Response.StatusCode = (int)context
                .GetRequiredService<IHttpExceptionStatusCodeFinder>()
                .GetStatusCode(context.HttpContext, context.Exception);

            context.Result = new ObjectResult(new RemoteServiceErrorResponse(remoteError));
        }
    }

    /// <summary>
    /// 构建 WrapResult
    /// </summary>
    private WrapResult<object> CreateWrapResult(ExceptionContext context)
    {
        var result = new WrapResult<object>();
        var localizer = context.GetRequiredService<IStringLocalizer<AbpProLocalizationResource>>();

        switch (context.Exception)
        {
            case AbpAuthorizationException:
                result.SetFail(localizer[$"{AbpProLocalizationConsts.NameSpace}:PermissionDenied"], $"{(int)HttpStatusCode.Unauthorized}");
                break;
            case AbpValidationException validation:
                var errorMessage = localizer[$"{AbpProLocalizationConsts.NameSpace}:ParameterValidationFailed"] + ";" + validation.ValidationErrors.JoinAsString(";");
                result.SetFail(errorMessage, $"{(int)HttpStatusCode.BadRequest}");
                break;
            case EntityNotFoundException:
                result.SetFail(localizer[$"{AbpProLocalizationConsts.NameSpace}:EntityNotFound"], $"{(int)HttpStatusCode.NotFound}");
                break;
            case NotImplementedException:
                result.SetFail(localizer[$"{AbpProLocalizationConsts.NameSpace}:Unimplemented"], $"{(int)HttpStatusCode.NotImplemented}");
                break;
            case DbUpdateConcurrencyException:
                result.SetFail(localizer[$"{AbpProLocalizationConsts.NameSpace}:DbUpdateConcurrency"], $"{(int)HttpStatusCode.Conflict}");
                break;
            default:
                if (context.Exception is IHasErrorCode codeException)
                {
                    var exceptionConverter = context.GetRequiredService<IAbpExceptionConverter>();
                    var message = exceptionConverter.TryToLocalizeExceptionMessage(context.Exception);

                    if (codeException.Code.IsNullOrWhiteSpace())
                        result.SetFail(message, $"{(int)HttpStatusCode.InternalServerError}");
                    else
                        result.SetFail(message, codeException.Code);
                }
                else
                {
                    result.SetFail(context.Exception.Message, $"{(int)HttpStatusCode.InternalServerError}");
                }
                break;
        }

        return result;
    }

    private bool ShouldWrapResult(ExceptionContext context)
    {
        var controllerAction = context.ActionDescriptor.AsControllerActionDescriptor();

        if (controllerAction == null) return false;

        if (controllerAction.ControllerTypeInfo.GetCustomAttributes(typeof(WrapResultAttribute), true).Any())
            return true;

        if (context.ActionDescriptor.GetMethodInfo().GetCustomAttributes(typeof(WrapResultAttribute), true).Any())
            return true;

        return false;
    }
}
