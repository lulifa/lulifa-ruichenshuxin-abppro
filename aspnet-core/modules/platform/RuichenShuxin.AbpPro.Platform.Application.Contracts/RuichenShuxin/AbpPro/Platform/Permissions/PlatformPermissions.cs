namespace RuichenShuxin.AbpPro.Platform;

public class PlatformPermissions
{
    public const string GroupName = "Platform";

    public static class DataDictionary
    {
        public const string Default = GroupName + ".DataDictionary";

        public const string Create = Default + ".Create";

        public const string Update = Default + ".Update";

        public const string Move = Default + ".Move";

        public const string Delete = Default + ".Delete";

        public const string ManageItems = Default + ".ManageItems";
    }

    public static class Layout
    {
        public const string Default = GroupName + ".Layout";

        public const string Create = Default + ".Create";

        public const string Update = Default + ".Update";

        public const string Delete = Default + ".Delete";
    }

    public static class Menu
    {
        public const string Default = GroupName + ".Menu";

        public const string Create = Default + ".Create";

        public const string Update = Default + ".Update";

        public const string Delete = Default + ".Delete";

        public const string ManageRoles = Default + ".ManageRoles";

        public const string ManageUsers = Default + ".ManageUsers";

        public const string ManageUserFavorites = Default + ".ManageUserFavorites";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(PlatformPermissions));
    }
}
