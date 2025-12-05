namespace RuichenShuxin.AbpPro;

public class SystemApplicationLocalizationAppService : AbpProAppService, ISystemApplicationLocalizationAppService
{
    protected readonly IAbpApplicationLocalizationAppService AbpApplicationLocalizationAppService;

    public SystemApplicationLocalizationAppService(IAbpApplicationLocalizationAppService abpApplicationLocalizationAppService)
    {
        AbpApplicationLocalizationAppService = abpApplicationLocalizationAppService;
    }

    public virtual async Task<ApplicationLocalizationDto> GetAsync(ApplicationLocalizationRequestDto input)
    {
        var result = await AbpApplicationLocalizationAppService.GetAsync(input);

        return result;

    }
}
