using Volo.Abp.DependencyInjection;

namespace RuichenShuxin.AbpPro;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(IAbpApplicationConfigurationAppService))]
public class SystemApplicationConfigurationAppService : AbpProAppService, IAbpApplicationConfigurationAppService
{
    protected readonly AbpApplicationConfigurationAppService AbpApplicationConfigurationAppService;

    public SystemApplicationConfigurationAppService(AbpApplicationConfigurationAppService abpApplicationConfigurationAppService)
    {
        AbpApplicationConfigurationAppService = abpApplicationConfigurationAppService;
    }


    public virtual async Task<ApplicationConfigurationDto> GetAsync(ApplicationConfigurationRequestOptions options)
    {
        var result = await AbpApplicationConfigurationAppService.GetAsync(options);

        return result;
    }
}
