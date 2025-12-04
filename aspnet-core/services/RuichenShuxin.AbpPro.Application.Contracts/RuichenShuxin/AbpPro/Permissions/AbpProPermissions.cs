namespace RuichenShuxin.AbpPro;

public static class AbpProPermissions
{
    public const string GroupName = AbpProCoreConsts.ApplicationName;


    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AbpProPermissions));
    }
}
