using RuichenShuxin.AbpPro.DataProtectionManagement.Localization;
using Volo.Abp.Application.Services;

namespace RuichenShuxin.AbpPro.DataProtectionManagement;

public abstract class DataProtectionManagementAppService : ApplicationService
{
    protected DataProtectionManagementAppService()
    {
        LocalizationResource = typeof(DataProtectionManagementResource);
        ObjectMapperContext = typeof(DataProtectionManagementApplicationModule);
    }
}
