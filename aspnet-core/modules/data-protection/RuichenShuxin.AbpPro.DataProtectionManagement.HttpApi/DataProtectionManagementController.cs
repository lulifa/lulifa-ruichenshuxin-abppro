using RuichenShuxin.AbpPro.DataProtectionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace RuichenShuxin.AbpPro.DataProtectionManagement;

public abstract class DataProtectionManagementController : AbpControllerBase
{
    protected DataProtectionManagementController()
    {
        LocalizationResource = typeof(DataProtectionManagementResource);
    }
}
