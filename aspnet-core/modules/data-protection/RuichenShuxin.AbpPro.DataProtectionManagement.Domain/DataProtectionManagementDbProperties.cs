namespace RuichenShuxin.AbpPro.DataProtectionManagement;

public static class DataProtectionManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "DataProtectionManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "DataProtectionManagement";
}
