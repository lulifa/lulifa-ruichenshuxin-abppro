namespace RuichenShuxin.AbpPro;

[DependsOn(
    typeof(AbpProHttpApiModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpProApplicationModule),
    typeof(AbpProEntityFrameworkCoreModule),
    typeof(AbpAccountWebOpenIddictModule),
    typeof(AbpProOAuthModule),
    typeof(AbpProCAPEventBusModule),
    typeof(AbpSwashbuckleModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpAspNetCoreSerilogModule)
    )]
public class AbpProHttpApiHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigureAbpProOpenIddict();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        context.Services.ConfigureAbpProSecurity()
                        .ConfigureAbpProAuthentication()
                        .ConfigureAbpProUrls()
                        .ConfigureAbpProBundles()
                        .ConfigureAbpProHealthChecks()
                        .ConfigureAbpProSwagger()
                        .ConfigureAbpProCors()
                        .ConfigureAbpProMultiTenancy()
                        .ConfigureAbpProExceptions()
                        .ConfigureAbpProDataSeed()
                        .ConfigureAbpProLocalization()
                        .ConfigureAbpProCache();
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
