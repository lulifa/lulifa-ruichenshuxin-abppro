namespace RuichenShuxin.AbpPro;

[Route("api/system/application-configuration")]
public class VoloApplicationConfigurationController : AbpProController, IVoloApplicationConfigurationAppService
{
    protected readonly IVoloApplicationConfigurationAppService Service;
    public VoloApplicationConfigurationController(IVoloApplicationConfigurationAppService service)
    {
        Service = service;
    }

    [HttpGet]
    public virtual async Task<ApplicationConfigurationDto> GetAsync(ApplicationConfigurationRequestOptions options)
    {
        return await Service.GetAsync(options);
    }
}
