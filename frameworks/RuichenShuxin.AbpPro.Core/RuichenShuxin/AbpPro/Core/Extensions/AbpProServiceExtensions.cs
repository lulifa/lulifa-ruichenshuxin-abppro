using Autofac.Core;
using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpenIddict.Server.AspNetCore;
using OpenIddict.Validation.AspNetCore;
using System;
using System.Linq;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict;
using Volo.Abp.Security.Claims;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace RuichenShuxin.AbpPro.Core;

public static class AbpProServiceExtensions
{
    /// <summary>
    /// 预配置OpenIddict
    /// </summary>
    public static IServiceCollection PreConfigureAbpProOpenIddict(this IServiceCollection services)
    {
        var authOptions = services.GetConfiguration().GetOptions<AuthServerOptions>();

        var globalOptions = services.GetConfiguration().GetOptions<GlobalOptions>();

        services.PreConfigure<OpenIddictBuilder>(builder =>
        {
            builder.AddValidation(options =>
            {
                options.AddAudiences(globalOptions.Scopes);
                options.UseLocalServer();
                options.UseAspNetCore();
            });
        });

        if (!services.GetHostingEnvironment().IsDevelopment())
        {
            services.PreConfigure<AbpOpenIddictAspNetCoreOptions>(options =>
            {
                options.AddDevelopmentEncryptionAndSigningCertificate = false;
            });

            services.PreConfigure<OpenIddictServerBuilder>(serverBuilder =>
            {
                serverBuilder.AddProductionEncryptionAndSigningCertificate("openiddict.pfx", authOptions.CertificatePassPhrase);
                serverBuilder.SetIssuer(new Uri(authOptions.Authority));
            });
        }

        return services;
    }

    /// <summary>
    /// 配置安全相关选项
    /// </summary>
    public static IServiceCollection ConfigureAbpProSecurity(this IServiceCollection services)
    {
        var appOptions = services.GetConfiguration().GetOptions<AppOptions>();

        var authOptions = services.GetConfiguration().GetOptions<AuthServerOptions>();

        // PII 配置
        if (!appOptions.DisablePII)
        {
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
            Microsoft.IdentityModel.Logging.IdentityModelEventSource.LogCompleteSecurityArtifact = true;
        }

        // HTTPS 配置
        if (!authOptions.RequireHttpsMetadata)
        {
            services.Configure<OpenIddictServerAspNetCoreOptions>(options =>
            {
                options.DisableTransportSecurityRequirement = true;
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedProto;
            });
        }

        return services;
    }

    /// <summary>
    /// 配置认证相关
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProAuthentication(this IServiceCollection services)
    {
        services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        services.Configure<AbpClaimsPrincipalFactoryOptions>(options =>
        {
            options.IsDynamicClaimsEnabled = true;
        });

        return services;
    }

    /// <summary>
    /// 配置Urls相关
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProUrls(this IServiceCollection services)
    {
        var appOptions = services.GetConfiguration().GetOptions<AppOptions>();

        services.Configure<AppUrlOptions>(options =>
        {
            options.Applications["MVC"].RootUrl = appOptions.SelfUrl;
            options.Applications["Angular"].RootUrl = appOptions.AngularUrl;
            options.Applications["Angular"].Urls[AbpProCoreConsts.Urls.PasswordReset] = "account/reset-password";
            options.RedirectAllowedUrls.AddRange(appOptions.RedirectAllowedUrls?.Split(',') ?? Array.Empty<string>());
        });

        return services;

    }

    /// <summary>
    /// Theme相关
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProBundles(this IServiceCollection services)
    {
        services.Configure<AbpBundlingOptions>(options =>
        {
            options.StyleBundles.Configure(
                LeptonXLiteThemeBundles.Styles.Global,
                bundle =>
                {
                    bundle.AddFiles("/global-styles.css");
                }
            );

            options.ScriptBundles.Configure(
                LeptonXLiteThemeBundles.Scripts.Global,
                bundle =>
                {
                    bundle.AddFiles("/global-scripts.js");
                }
            );
        });

        return services;
    }

    /// <summary>
    /// Swagger相关配置
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProSwagger(this IServiceCollection services)
    {
        var authOptions = services.GetConfiguration().GetOptions<AuthServerOptions>();

        var globalOptions = services.GetConfiguration().GetOptions<GlobalOptions>();

        services.AddAbpSwaggerGenWithOidc(
            authOptions.Authority,
            globalOptions.Scopes,
            [AbpSwaggerOidcFlows.AuthorizationCode],
            null,
            options =>
            {
                options.SwaggerDoc(AbpProCoreConsts.Swagger.Version, new OpenApiInfo { Title = AbpProCoreConsts.Swagger.ApiTitle, Version = AbpProCoreConsts.Swagger.Version });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);

                options.DocumentFilter<AbpProHideDefaultApiFilter>();
                options.OperationFilter<AbpProOperationFilter>();

            });

        return services;

    }

    /// <summary>
    /// 跨域相关配置
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProCors(this IServiceCollection services)
    {
        var appOptions = services.GetConfiguration().GetOptions<AppOptions>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        appOptions.CorsOrigins?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.Trim().RemovePostFix("/"))
                            .ToArray() ?? Array.Empty<string>()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }

    /// <summary>
    /// 健康检查相关配置
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProHealthChecks(this IServiceCollection services)
    {
        services.AddAbpProHealthChecks();

        return services;

    }

    /// <summary>
    /// 多租户相关配置
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProMultiTenancy(this IServiceCollection services)
    {
        var multiTenancyOptions = services.GetConfiguration().GetOptions<MultiTenancyOptions>();

        services.Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = multiTenancyOptions.Enabled;
        });

        return services;

    }

    public static IServiceCollection ConfigureAbpProExceptions(this IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add(typeof(AbpProExceptionFilter));

            options.Filters.Add(typeof(AbpProResultFilter));

        });

        return services;
    }

}
