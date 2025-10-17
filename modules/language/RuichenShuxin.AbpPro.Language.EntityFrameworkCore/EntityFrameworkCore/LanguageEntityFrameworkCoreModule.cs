using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro.Language.EntityFrameworkCore;

[DependsOn(
    typeof(LanguageDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class LanguageEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<LanguageDbContext>(options =>
        {
            options.AddDefaultRepositories<ILanguageDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
