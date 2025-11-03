namespace RuichenShuxin.AbpPro;

[Authorize]
public class SystemConfigurationAppService : AbpProAppService, ISystemConfigurationAppService
{
    protected readonly IAbpApplicationConfigurationAppService Original;
    public SystemConfigurationAppService(IAbpApplicationConfigurationAppService abpApplicationConfigurationAppService)
    {
        Original = abpApplicationConfigurationAppService;
    }

    public virtual async Task<ApplicationConfigurationDto> GetAsync(ApplicationConfigurationRequestOptions options)
    {
        var result = await Original.GetAsync(options);

        return result;
    }
}
