namespace RuichenShuxin.AbpPro;

public class AbpProPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpProPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(AbpProPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AbpProPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AbpProPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AbpProPermissions.Books.Delete, L("Permission:Books.Delete"));


        var identityGroup = context.GetGroupOrNull(IdentityPermissions.GroupName);
        if (identityGroup != null)
        {
            var userPermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Users.Default);
            if (userPermission != null)
            {
                userPermission.AddChild(AbpProPermissions.Users.ResetPassword, L("Permission:ResetPassword"));
                userPermission.AddChild(AbpProPermissions.Users.ManageOrganizationUnits, L("Permission:ManageOrganizationUnits"));
            }

            var rolePermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Roles.Default);
            if (rolePermission != null)
            {
                rolePermission.AddChild(AbpProPermissions.Roles.ManageOrganizationUnits, L("Permission:ManageOrganizationUnits"));
            }

            var origanizationUnitPermission = identityGroup.AddPermission(AbpProPermissions.OrganizationUnits.Default, L("Permission:OrganizationUnitManagement"));
            origanizationUnitPermission.AddChild(AbpProPermissions.OrganizationUnits.Create, L("Permission:Create"));
            origanizationUnitPermission.AddChild(AbpProPermissions.OrganizationUnits.Update, L("Permission:Edit"));
            origanizationUnitPermission.AddChild(AbpProPermissions.OrganizationUnits.Delete, L("Permission:Delete"));
            origanizationUnitPermission.AddChild(AbpProPermissions.OrganizationUnits.ManageRoles, L("Permission:ManageRoles"));
            origanizationUnitPermission.AddChild(AbpProPermissions.OrganizationUnits.ManageUsers, L("Permission:ManageUsers"));
            origanizationUnitPermission.AddChild(AbpProPermissions.OrganizationUnits.ManagePermissions, L("Permission:ChangePermissions"));

        }

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpProResource>(name);
    }
}
