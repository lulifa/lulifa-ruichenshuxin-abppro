namespace RuichenShuxin.AbpPro;

/// <summary>
/// 租户管理
/// 🚢🌞🌛✨
/// </summary>
[Route("api/system/tenant")]
public class SystemTenantController : AbpProController<
    ISystemTenantAppService,
    TenantDto,
    TenantGetListInput,
    TenantCreateDto,
    TenantUpdateDto>
{
    public SystemTenantController(ISystemTenantAppService appService) : base(appService)
    {
    }


    [HttpGet("find-by-name")]
    public async Task<FindTenantResultDto> FindTenantByNameAsync(string name)
    {
        return await AppService.FindTenantByNameAsync(name);
    }

    [HttpGet("by-name/{name}")]
    public async Task<TenantDto> GetAsync(string name)
    {
        return await AppService.GetAsync(name);
    }

}
