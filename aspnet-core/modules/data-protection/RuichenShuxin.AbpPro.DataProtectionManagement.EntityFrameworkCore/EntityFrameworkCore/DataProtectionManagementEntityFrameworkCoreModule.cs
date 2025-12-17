using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro.DataProtectionManagement.EntityFrameworkCore;

[DependsOn(
    typeof(DataProtectionManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class DataProtectionManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<DataProtectionManagementDbContext>(options =>
        {
            options.AddDefaultRepositories<IDataProtectionManagementDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
