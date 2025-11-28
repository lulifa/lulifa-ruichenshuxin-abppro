namespace RuichenShuxin.AbpPro.Platform;

[DependsOn(
    typeof(PlatformApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class PlatformHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(PlatformApplicationContractsModule).Assembly,
            PlatformRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<PlatformHttpApiClientModule>();
        });

    }
}
