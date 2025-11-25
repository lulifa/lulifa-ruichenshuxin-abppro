namespace RuichenShuxin.AbpPro.Localization;

public interface IAbpProExceptionConverter
{
    string TryToLocalizeExceptionMessage(Exception exception);
}