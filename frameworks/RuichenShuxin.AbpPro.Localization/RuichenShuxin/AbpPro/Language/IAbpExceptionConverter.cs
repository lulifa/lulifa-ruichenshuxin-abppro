namespace RuichenShuxin.AbpPro.Language;

public interface IAbpExceptionConverter
{
    string TryToLocalizeExceptionMessage(Exception exception);
}