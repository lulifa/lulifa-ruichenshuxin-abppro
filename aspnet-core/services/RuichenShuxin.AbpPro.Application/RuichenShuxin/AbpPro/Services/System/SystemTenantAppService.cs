namespace RuichenShuxin.AbpPro;

[Authorize(TenantManagementPermissions.Tenants.Default)]
public class SystemTenantAppService : AbpProAppService, ISystemTenantAppService
{
    protected readonly IAbpTenantAppService _abpTenantAppService;
    private readonly ITenantAppService _tenantAppService;

    public SystemTenantAppService(IAbpTenantAppService abpTenantAppService, ITenantAppService tenantAppService)
    {
        _abpTenantAppService = abpTenantAppService;
        _tenantAppService = tenantAppService;
    }

    [AllowAnonymous]
    public virtual async Task<FindTenantResultDto> FindTenantByNameAsync(string name)
    {
        var result = await _abpTenantAppService.FindTenantByNameAsync(name);

        return result;

    }

    [AllowAnonymous]
    public virtual async Task<FindTenantResultDto> FindTenantByIdAsync(Guid id)
    {
        var result = await _abpTenantAppService.FindTenantByIdAsync(id);

        return result;
    }

    public Task<string> GetDefaultConnectionStringAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDefaultConnectionStringAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TenantDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)
    {
        throw new NotImplementedException();
    }

    public Task<TenantDto> CreateAsync(TenantCreateDto input)
    {
        throw new NotImplementedException();
    }

    public Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
