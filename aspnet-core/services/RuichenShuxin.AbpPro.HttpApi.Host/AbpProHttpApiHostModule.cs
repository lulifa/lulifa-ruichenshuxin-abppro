namespace RuichenShuxin.AbpPro;

[DependsOn(
    typeof(AbpProHttpApiModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpProApplicationModule),
    typeof(AbpProEntityFrameworkCoreModule),
    typeof(AbpAccountWebOpenIddictModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreSerilogModule),

    typeof(AbpProAuthorizationOrganizationUnitsModule),
    typeof(AbpProCAPEventBusModule),
    typeof(AbpProLocalizationModule),
    typeof(AbpProOAuthModule),
    typeof(AbpProAspNetCoreMvcWrapperModule),
    typeof(AbpProCoreModule)
    )]
public partial class AbpProHttpApiHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        PreConfigureOpenIddict(configuration, hostingEnvironment);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        ConfigureWrapper();
        ConfigureSecurity(configuration);
        ConfigureAuthentication(services, configuration);
        ConfigureUrls(configuration);
        ConfigureBundles();
        ConfigureHealthChecks(services);
        ConfigureCors(services, configuration);
        ConfigureMultiTenancy(configuration);
        ConfigureDataSeed(services);
        ConfigureLocalization(configuration);
        ConfigureCache(services, configuration, hostingEnvironment);
        ConfigureSwagger(services, configuration);
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {

        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        var configuration = context.GetConfiguration();

        app.UseForwardedHeaders();
        app.UseAbpProRequestLocalization();
        app.UseCookiePolicy();

        app.UseRouting();
        app.MapAbpStaticAssets();
        app.UseAbpSecurityHeaders();
        app.UseCors();
        app.UseAuthentication();
        app.UseAbpOpenIddictValidation();

        app.UseAbpProMultiTenancy(configuration);

        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseAuthorization();

        app.UseAbpProSwagger(configuration);
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}
