namespace RuichenShuxin.AbpPro.UI;

public interface IAbpProUIExceptionConverter
{
    string TryToLocalizeExceptionMessage(Exception exception);
}