namespace RuichenShuxin.AbpPro.DataProtectionManagement;

public abstract class DataProtectionManagementApplicationServiceBase : ApplicationService
{
    protected DataProtectionManagementApplicationServiceBase()
    {
        LocalizationResource = typeof(DataProtectionResource);
        ObjectMapperContext = typeof(DataProtectionManagementApplicationModule);
    }
}
