namespace RuichenShuxin.AbpPro;

[Authorize(TenantManagementPermissions.Tenants.Default)]
public class SystemTenantAppService : AbpProAppService, ISystemTenantAppService
{
    protected IAbpTenantAppService AbpTenantAppService { get; }
    protected IDistributedEventBus EventBus { get; }
    protected ITenantRepository TenantRepository { get; }
    protected ITenantManager TenantManager { get; }
    protected IDataSeeder DataSeeder { get; }

    public SystemTenantAppService(
        IAbpTenantAppService abpTenantAppService,
        ITenantRepository tenantRepository,
        ITenantManager tenantManager,
        IDistributedEventBus eventBus,
        IDataSeeder dataSeeder)
    {
        AbpTenantAppService = abpTenantAppService;
        EventBus = eventBus;
        TenantRepository = tenantRepository;
        TenantManager = tenantManager;
        DataSeeder = dataSeeder;
    }


    [AllowAnonymous]
    public virtual async Task<FindTenantResultDto> FindTenantByNameAsync(string name)
    {
        var result = await AbpTenantAppService.FindTenantByNameAsync(name);

        return result;
    }

    public virtual async Task<TenantDto> GetAsync(Guid id)
    {
        var tenant = await TenantRepository.FindAsync(id);
        if (tenant == null)
        {
            throw new BusinessException(SystemTenantErrorCodes.TenantIdOrNameNotFound)
                .WithData("Tenant", id);
        }
        return ObjectMapper.Map<Tenant, TenantDto>(tenant);
    }

    public virtual async Task<PagedResultDto<TenantDto>> GetListAsync(TenantGetListInput input)
    {
        var count = await TenantRepository.GetCountAsync(input.Filter);
        var list = await TenantRepository.GetListAsync(
            input.Sorting,
            input.MaxResultCount,
            input.SkipCount,
            input.Filter
        );

        return new PagedResultDto<TenantDto>(
            count,
            ObjectMapper.Map<List<Tenant>, List<TenantDto>>(list)
        );
    }

    [Authorize(TenantManagementPermissions.Tenants.Create)]
    public virtual async Task<TenantDto> CreateAsync(TenantCreateDto input)
    {
        var tenant = await TenantManager.CreateAsync(input.Name);

        tenant.SetIsActive(input.IsActive);

        tenant.SetEnableTime(input.EnableTime);

        tenant.SetDisableTime(input.DisableTime);

        input.MapExtraPropertiesTo(tenant);

        if (!input.UseSharedDatabase)
        {
            tenant.SetDefaultConnectionString(input.DefaultConnectionString);

            foreach (var connectionString in input.ConnectionStrings)
            {
                tenant.SetConnectionString(connectionString.Name, connectionString.Value);
            }

        }

        await TenantRepository.InsertAsync(tenant);

        CurrentUnitOfWork.OnCompleted(async () =>
        {
            var eto = new TenantCreatedEto
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Properties =
                {
                    { IdentityDataSeedContributor.AdminEmailPropertyName, input.AdminEmailAddress },
                    { IdentityDataSeedContributor.AdminPasswordPropertyName, input.AdminPassword }
                }
            };
            await EventBus.PublishAsync(eto);
        });


        await CurrentUnitOfWork.SaveChangesAsync();

        using (CurrentTenant.Change(tenant.Id, tenant.Name))
        {
            await DataSeeder.SeedAsync(
                            new DataSeedContext(tenant.Id)
                                .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, input.AdminEmailAddress)
                                .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName, input.AdminPassword)
                            );
        }

        return ObjectMapper.Map<Tenant, TenantDto>(tenant);

    }

    [Authorize(TenantManagementPermissions.Tenants.Create)]
    public virtual async Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    {
        var tenant = await TenantRepository.GetAsync(id);

        if (!string.Equals(tenant.Name, input.Name))
        {
            await TenantManager.ChangeNameAsync(tenant, input.Name);
        }

        tenant.SetIsActive(input.IsActive);

        tenant.SetEnableTime(input.EnableTime);

        tenant.SetDisableTime(input.DisableTime);

        tenant.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

        input.MapExtraPropertiesTo(tenant);

        await TenantRepository.UpdateAsync(tenant);

        await CurrentUnitOfWork.SaveChangesAsync();

        return ObjectMapper.Map<Tenant, TenantDto>(tenant);

    }

    [Authorize(TenantManagementPermissions.Tenants.Create)]
    public virtual async Task DeleteAsync(Guid id)
    {
        var tenant = await TenantRepository.FindAsync(id);

        if (tenant == null)
        {
            return;
        }

        await TenantRepository.DeleteAsync(tenant);

        await CurrentUnitOfWork.SaveChangesAsync();

    }
}
