namespace RuichenShuxin.AbpPro.Localization;

public interface IAbpExceptionConverter
{
    string TryToLocalizeExceptionMessage(Exception exception);
}