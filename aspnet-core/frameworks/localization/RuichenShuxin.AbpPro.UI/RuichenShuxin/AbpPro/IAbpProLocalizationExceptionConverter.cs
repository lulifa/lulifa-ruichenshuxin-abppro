namespace RuichenShuxin.AbpPro.Localization;

public interface IAbpProLocalizationExceptionConverter
{
    string TryToLocalizeExceptionMessage(Exception exception);
}