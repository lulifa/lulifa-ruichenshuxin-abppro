using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro.DataProtectionManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(DataProtectionManagementDomainSharedModule)
)]
public class DataProtectionManagementDomainModule : AbpModule
{

}
