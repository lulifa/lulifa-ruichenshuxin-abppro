using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace RuichenShuxin.AbpPro.Language;

[DependsOn(
    typeof(LanguageDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class LanguageApplicationContractsModule : AbpModule
{

}
