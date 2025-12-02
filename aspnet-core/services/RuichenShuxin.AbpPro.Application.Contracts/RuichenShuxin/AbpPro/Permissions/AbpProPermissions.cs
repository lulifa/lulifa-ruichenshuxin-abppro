namespace RuichenShuxin.AbpPro;

public static class AbpProPermissions
{
    public const string GroupName = "AbpPro";


    public static class Books
    {
        public const string Default = GroupName + ".Books";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Users
    {
        public const string ResetPassword = IdentityPermissions.Users.Default + ".ResetPassword";
        public const string ManageOrganizationUnits = IdentityPermissions.Users.Default + ".ManageOrganizationUnits";
    }

    public static class Roles
    {
        public const string ManageOrganizationUnits = IdentityPermissions.Roles.Default + ".ManageOrganizationUnits";
    }

    public static class OrganizationUnits
    {
        public const string Default = IdentityPermissions.GroupName + ".OrganizationUnits";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string ManageUsers = Default + ".ManageUsers";
        public const string ManageRoles = Default + ".ManageRoles";
        public const string ManagePermissions = Default + ".ManagePermissions";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AbpProPermissions));
    }
}
