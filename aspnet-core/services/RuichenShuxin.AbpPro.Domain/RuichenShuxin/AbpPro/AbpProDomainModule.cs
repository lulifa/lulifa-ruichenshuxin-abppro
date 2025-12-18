namespace RuichenShuxin.AbpPro;

[DependsOn(
     typeof(AbpAutoMapperModule),
     typeof(AbpDddDomainModule),
     typeof(AbpProDomainSharedModule))]
public class AbpProDomainModule : AbpModule
{
}
