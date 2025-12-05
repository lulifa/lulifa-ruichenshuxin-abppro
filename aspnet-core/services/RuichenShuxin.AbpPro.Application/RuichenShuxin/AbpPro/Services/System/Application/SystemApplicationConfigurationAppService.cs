namespace RuichenShuxin.AbpPro;

public class SystemApplicationConfigurationAppService : AbpProAppService, ISystemApplicationConfigurationAppService
{
    protected readonly IAbpApplicationConfigurationAppService AbpApplicationConfigurationAppService;

    public SystemApplicationConfigurationAppService(IAbpApplicationConfigurationAppService abpApplicationConfigurationAppService)
    {
        AbpApplicationConfigurationAppService = abpApplicationConfigurationAppService;
    }


    public virtual async Task<ApplicationConfigurationDto> GetAsync(ApplicationConfigurationRequestOptions options)
    {
        var result = await AbpApplicationConfigurationAppService.GetAsync(options);

        return result;
    }
}
