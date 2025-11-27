namespace RuichenShuxin.AbpPro.Platform;

[DependsOn(
    typeof(PlatformDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class PlatformApplicationContractsModule : AbpModule
{

}
