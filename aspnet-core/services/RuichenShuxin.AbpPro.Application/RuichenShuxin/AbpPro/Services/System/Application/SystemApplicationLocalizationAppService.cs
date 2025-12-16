using Volo.Abp.DependencyInjection;

namespace RuichenShuxin.AbpPro;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IAbpApplicationLocalizationAppService))]
public class SystemApplicationLocalizationAppService : AbpProAppService, IAbpApplicationLocalizationAppService
{
    protected readonly AbpApplicationLocalizationAppService AbpApplicationLocalizationAppService;

    public SystemApplicationLocalizationAppService(AbpApplicationLocalizationAppService abpApplicationLocalizationAppService)
    {
        AbpApplicationLocalizationAppService = abpApplicationLocalizationAppService;
    }

    public virtual async Task<ApplicationLocalizationDto> GetAsync(ApplicationLocalizationRequestDto input)
    {
        var result = await AbpApplicationLocalizationAppService.GetAsync(input);

        return result;

    }
}
