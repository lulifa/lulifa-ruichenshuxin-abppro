namespace RuichenShuxin.AbpPro;

/// <summary>
/// 系统应用多语言
/// </summary>
[Route("api/system/application-localization")]
public class SystemApplicationLocalizationController : AbpProController, ISystemApplicationLocalizationAppService
{
    protected readonly ISystemApplicationLocalizationAppService SystemApplicationLocalizationAppService;

    public SystemApplicationLocalizationController(ISystemApplicationLocalizationAppService systemApplicationLocalizationAppService)
    {
        SystemApplicationLocalizationAppService = systemApplicationLocalizationAppService;
    }


    [HttpGet]
    public virtual async Task<ApplicationLocalizationDto> GetAsync(ApplicationLocalizationRequestDto input)
    {
        return await SystemApplicationLocalizationAppService.GetAsync(input);
    }
}
