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


    /// <summary>
    /// 通过租户名称查找租户（返回租户基本信息）
    /// </summary>
    [HttpGet("find-by-name")]
    public async Task<FindTenantResultDto> FindTenantByNameAsync(string name)
    {
        return await AppService.FindTenantByNameAsync(name);
    }


    /// <summary>
    /// 获取指定租户详情（通过名称）
    /// </summary>
    [HttpGet("by-name/{name}")]
    public async Task<TenantDto> GetAsync(string name)
    {
        return await AppService.GetAsync(name);
    }

}
