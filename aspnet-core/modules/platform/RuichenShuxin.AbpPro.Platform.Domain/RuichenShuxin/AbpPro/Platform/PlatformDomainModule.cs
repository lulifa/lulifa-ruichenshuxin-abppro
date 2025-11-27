using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace RuichenShuxin.AbpPro.Platform;

[DependsOn(
    typeof(AbpEventBusModule),
    typeof(AbpDddDomainModule),
    typeof(PlatformDomainSharedModule)
)]
public class PlatformDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<PlatformDomainModule>();

        Configure<DataItemMappingOptions>(options =>
        {
            options.SetDefaultMapping();
        });

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<PlatformDomainMappingProfile>(validate: true);
        });

        Configure<AbpDistributedEntityEventOptions>(options =>
        {
            options.EtoMappings.Add<Layout, LayoutEto>(typeof(PlatformDomainModule));
            options.EtoMappings.Add<Menu, MenuEto>(typeof(PlatformDomainModule));
            options.EtoMappings.Add<UserMenu, UserMenuEto>(typeof(PlatformDomainModule));
            options.EtoMappings.Add<RoleMenu, RoleMenuEto>(typeof(PlatformDomainModule));
        });
    }
}
