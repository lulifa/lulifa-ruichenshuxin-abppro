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


        var authorsPermission = myGroup.AddPermission(
            AbpProPermissions.Authors.Default, L("Permission:Authors"));
        authorsPermission.AddChild(
            AbpProPermissions.Authors.Create, L("Permission:Authors.Create"));
        authorsPermission.AddChild(
            AbpProPermissions.Authors.Edit, L("Permission:Authors.Edit"));
        authorsPermission.AddChild(
            AbpProPermissions.Authors.Delete, L("Permission:Authors.Delete"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpProResource>(name);
    }
}
