namespace RuichenShuxin.AbpPro;

public class VoloApplicationConfigurationAppService : AbpProAppService, IVoloApplicationConfigurationAppService
{
    protected readonly IAbpApplicationConfigurationAppService Original;
    public VoloApplicationConfigurationAppService(IAbpApplicationConfigurationAppService abpApplicationConfigurationAppService)
    {
        Original = abpApplicationConfigurationAppService;
    }

    public virtual async Task<ApplicationConfigurationDto> GetAsync(ApplicationConfigurationRequestOptions options)
    {
        var result = await Original.GetAsync(options);

        return result;
    }
}
