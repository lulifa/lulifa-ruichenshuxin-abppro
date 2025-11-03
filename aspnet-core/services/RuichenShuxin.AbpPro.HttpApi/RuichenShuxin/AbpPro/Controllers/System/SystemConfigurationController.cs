namespace RuichenShuxin.AbpPro;

/// <summary>
/// 系统配置管理
/// 🚢🌞🌛✨
/// </summary>
[Route("api/system/configurations")]
public class SystemConfigurationController : AbpProController, ISystemConfigurationAppService
{
    protected readonly ISystemConfigurationAppService Service;
    public SystemConfigurationController(ISystemConfigurationAppService service)
    {
        Service = service;
    }

    [HttpGet]
    public virtual async Task<ApplicationConfigurationDto> GetAsync(ApplicationConfigurationRequestOptions options)
    {
        return await Service.GetAsync(options);
    }
}
