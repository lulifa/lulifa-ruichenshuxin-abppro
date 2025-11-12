namespace RuichenShuxin.AbpPro;

public interface ISystemTenantAppService :
        ICrudAppService<
            TenantDto,
            Guid,
            TenantGetListInput,
            TenantCreateDto,
            TenantUpdateDto>
{

    Task<FindTenantResultDto> FindTenantByNameAsync(string name);
    Task<TenantDto> GetAsync([Required] string name);
}
