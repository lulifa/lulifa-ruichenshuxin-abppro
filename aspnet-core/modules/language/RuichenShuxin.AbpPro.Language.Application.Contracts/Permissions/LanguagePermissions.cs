using Volo.Abp.Reflection;

namespace RuichenShuxin.AbpPro.Language.Permissions;

public class LanguagePermissions
{
    public const string GroupName = "Language";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(LanguagePermissions));
    }
}
