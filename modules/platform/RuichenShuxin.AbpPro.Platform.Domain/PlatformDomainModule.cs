using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro.Platform;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(PlatformDomainSharedModule)
)]
public class PlatformDomainModule : AbpModule
{

}
