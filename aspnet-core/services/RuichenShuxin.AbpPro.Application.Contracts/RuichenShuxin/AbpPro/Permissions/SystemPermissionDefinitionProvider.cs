namespace RuichenShuxin.AbpPro;

public class SystemPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var identityGroup = context.GetGroupOrNull(IdentityPermissions.GroupName);
        if (identityGroup != null)
        {
            var userPermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Users.Default);
            if (userPermission != null)
            {
                userPermission.AddChild(SystemPermissions.Users.ResetPassword, L("Permission:ResetPassword"));
                userPermission.AddChild(SystemPermissions.Users.ManageOrganizationUnits, L("Permission:ManageOrganizationUnits"));
            }

            var rolePermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Roles.Default);
            if (rolePermission != null)
            {
                rolePermission.AddChild(SystemPermissions.Roles.ManageOrganizationUnits, L("Permission:ManageOrganizationUnits"));
            }

            var origanizationUnitPermission = identityGroup.AddPermission(SystemPermissions.OrganizationUnits.Default, L("Permission:OrganizationUnitManagement"));
            origanizationUnitPermission.AddChild(SystemPermissions.OrganizationUnits.Create, L("Permission:Create"));
            origanizationUnitPermission.AddChild(SystemPermissions.OrganizationUnits.Update, L("Permission:Edit"));
            origanizationUnitPermission.AddChild(SystemPermissions.OrganizationUnits.Delete, L("Permission:Delete"));
            origanizationUnitPermission.AddChild(SystemPermissions.OrganizationUnits.ManageRoles, L("Permission:ManageRoles"));
            origanizationUnitPermission.AddChild(SystemPermissions.OrganizationUnits.ManageUsers, L("Permission:ManageUsers"));
            origanizationUnitPermission.AddChild(SystemPermissions.OrganizationUnits.ManagePermissions, L("Permission:ChangePermissions"));

        }
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpProResource>(name);
    }
}
