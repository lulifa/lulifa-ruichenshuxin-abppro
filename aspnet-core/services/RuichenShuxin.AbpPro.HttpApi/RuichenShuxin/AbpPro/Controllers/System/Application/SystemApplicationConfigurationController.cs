namespace RuichenShuxin.AbpPro;

/// <summary>
/// 系统应用配置
/// </summary>
[Route("api/system/application-configuration")]
public class SystemApplicationConfigurationController : AbpProController, ISystemApplicationConfigurationAppService
{
    protected readonly ISystemApplicationConfigurationAppService SystemApplicationConfigurationAppService;
    protected readonly IAbpAntiForgeryManager AntiForgeryManager;

    public SystemApplicationConfigurationController(
        ISystemApplicationConfigurationAppService systemApplicationConfigurationAppService,
        IAbpAntiForgeryManager antiForgeryManager)
    {
        SystemApplicationConfigurationAppService = systemApplicationConfigurationAppService;
        AntiForgeryManager = antiForgeryManager;
    }


    [HttpGet]
    public virtual async Task<ApplicationConfigurationDto> GetAsync(ApplicationConfigurationRequestOptions options)
    {
        AntiForgeryManager.SetCookie();
        return await SystemApplicationConfigurationAppService.GetAsync(options);
    }
}
