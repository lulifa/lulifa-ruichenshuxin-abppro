using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace RuichenShuxin.AbpPro.Platform;

[DependsOn(
    typeof(PlatformDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PlatformApplicationContractsModule : AbpModule
{

}
