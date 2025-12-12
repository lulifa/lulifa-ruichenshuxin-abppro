namespace RuichenShuxin.AbpPro.Core;

public class AbpProCoreWrapResult<T>
{
    public string Code { get; private set; }

    public string Message { get; private set; }

    public string Details { get; set; }

    public T Result { get; private set; }

    public AbpProCoreWrapResult()
    {

    }

    public void SetSuccess(T result, string message = "OK", string code = "200", string details = null)
    {
        Result = result;
        Message = message;
        Code = code;
        Details = details;
    }

    public void SetFail(string message = "Fail", string code = "500", string details = null)
    {
        Message = message;
        Code = code;
        Details = details;
    }

}
