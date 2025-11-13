namespace RuichenShuxin.AbpPro;

/// <summary>
/// 租户管理
/// 🚢🌞🌛✨
/// </summary>
[Route("api/system/tenants")]
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


    [HttpGet]
    [Route("by-name/{name}")]
    public async Task<FindTenantResultDto> FindTenantByNameAsync(string name)
    {
        return await AppService.FindTenantByNameAsync(name);
    }

}
