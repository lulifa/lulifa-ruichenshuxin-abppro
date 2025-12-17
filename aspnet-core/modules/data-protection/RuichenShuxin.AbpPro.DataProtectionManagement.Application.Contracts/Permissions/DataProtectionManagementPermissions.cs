using Volo.Abp.Reflection;

namespace RuichenShuxin.AbpPro.DataProtectionManagement.Permissions;

public class DataProtectionManagementPermissions
{
    public const string GroupName = "DataProtectionManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(DataProtectionManagementPermissions));
    }
}
