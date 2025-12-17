using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace RuichenShuxin.AbpPro.DataProtectionManagement;

[DependsOn(
    typeof(DataProtectionManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class DataProtectionManagementApplicationContractsModule : AbpModule
{

}
