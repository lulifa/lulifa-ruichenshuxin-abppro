using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace RuichenShuxin.AbpPro.Language;

[DependsOn(
    typeof(LanguageApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class LanguageHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(LanguageApplicationContractsModule).Assembly,
            LanguageRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LanguageHttpApiClientModule>();
        });

    }
}
