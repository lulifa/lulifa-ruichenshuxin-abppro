using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RuichenShuxin.AbpPro.Core;
using RuichenShuxin.AbpPro.EntityFrameworkCore;
using RuichenShuxin.AbpPro.OAuth;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

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
    typeof(AbpSwashbuckleModule),
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
                        .ConfigureAbpProDataSeed();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {

        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        var configuration = context.GetConfiguration();

        app.UseForwardedHeaders();
        app.UseAbpProRequestLocalization();

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
