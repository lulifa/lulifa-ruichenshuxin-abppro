using Volo.Abp.AspNetCore.Mvc.AntiForgery;

namespace RuichenShuxin.AbpPro.Core;

public static class AbpProCoreServiceExtensions
{
    /// <summary>
    /// 预配置OpenIddict
    /// </summary>
    public static IServiceCollection PreConfigureAbpProOpenIddict(this IServiceCollection services)
    {
        var authOptions = services.GetConfiguration().GetOptions<AuthServerOptions>();

        services.PreConfigure<OpenIddictBuilder>(builder =>
        {
            builder.AddValidation(options =>
            {
                options.AddAudiences(authOptions.Scopes);
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

        // CSRF/XSRF https://abp.io/docs/latest/framework/infrastructure/csrf-anti-forgery
        services.Configure<AbpAntiForgeryOptions>(options =>
        {
            options.AutoValidate = true;
        });

        services.AddSameSiteCookiePolicy();

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
            options.Applications["Vue"].RootUrl = appOptions.VueUrl;
            options.Applications["Vue"].Urls[AbpProCoreConsts.Urls.PasswordReset] = "account/reset-password";
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

        services.AddAbpSwaggerGenWithOidc(
            authOptions.Authority,
            authOptions.Scopes,
            [AbpSwaggerOidcFlows.AuthorizationCode],
            null,
            options =>
            {
                options.SwaggerDoc(AbpProCoreConsts.Swagger.Version, new OpenApiInfo
                {
                    Title = AbpProCoreConsts.Swagger.ApiTitle,
                    Version = AbpProCoreConsts.Swagger.Version
                });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);

                options.DocumentFilter<AbpProCoreHideDefaultApiFilter>();
                options.OperationFilter<AbpProCoreOperationFilter>();

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
                    .WithExposedHeaders(AbpProCoreConsts.AbpWrapResult)
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
            options.IsEnabled = multiTenancyOptions.IsEnabled;
        });

        return services;

    }

    /// <summary>
    /// 异常过滤相关配置
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProExceptions(this IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add(typeof(AbpProCoreExceptionFilter));

            options.Filters.Add(typeof(AbpProCoreResultFilter));

        });

        return services;
    }

    /// <summary>
    /// 种子数据相关配置
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProDataSeed(this IServiceCollection services)
    {
        services.AddHostedService<AbpProCoreDataSeedWorker>();

        return services;
    }

    /// <summary>
    /// 多语言相关配置
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProLocalization(this IServiceCollection services)
    {
        services.Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));

            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("is", "is", "Icelandic"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ro-RO", "ro-RO", "Română"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("sv", "sv", "Svenska"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
        });

        return services;

    }

    /// <summary>
    /// 分布式缓存相关配置
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection ConfigureAbpProCache(this IServiceCollection services)
    {
        var redisOptions = services.GetConfiguration().GetOptions<RedisOptions>();

        services.Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = $"{AbpProCoreConsts.ApplicationName}:";
        });

        var dataProtectionBuilder = services.AddDataProtection().SetApplicationName(AbpProCoreConsts.ApplicationName);

        if (redisOptions.IsEnabled)
        {
            services.Configure<RedisCacheOptions>(options =>
            {
                options.Configuration = redisOptions.Configuration;
                options.InstanceName = redisOptions.InstanceName;
            });

            var redis = ConnectionMultiplexer.Connect(redisOptions.Configuration);

            services.AddSingleton<IDistributedLockProvider>(sp =>
            {
                return new RedisDistributedSynchronizationProvider(redis.GetDatabase());
            });

            if (!services.GetHostingEnvironment().IsDevelopment())
            {
                dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, $"{AbpProCoreConsts.ApplicationName}-Protection-Keys");
            }
        }

        return services;

    }

}
