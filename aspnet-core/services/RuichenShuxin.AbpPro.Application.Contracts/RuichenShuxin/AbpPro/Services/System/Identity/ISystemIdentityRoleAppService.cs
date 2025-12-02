namespace RuichenShuxin.AbpPro;

public interface ISystemIdentityRoleAppService
    : ICrudAppService<
        IdentityRoleDto,
        Guid,
        GetIdentityRolesInput,
        IdentityRoleCreateDto,
        IdentityRoleUpdateDto>
{

    Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnitsAsync(Guid id);

    Task SetOrganizationUnitsAsync(Guid id, IdentityRoleAddOrRemoveOrganizationUnitDto input);

    Task RemoveOrganizationUnitsAsync(Guid id, Guid ouId);

    Task<ListResultDto<IdentityRoleDto>> GetAllListAsync();
}
