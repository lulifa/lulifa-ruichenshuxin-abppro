using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro.Language;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(LanguageDomainSharedModule)
)]
public class LanguageDomainModule : AbpModule
{

}
