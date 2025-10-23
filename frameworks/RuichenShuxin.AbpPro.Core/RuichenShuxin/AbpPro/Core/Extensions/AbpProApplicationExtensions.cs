using Autofac.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace RuichenShuxin.AbpPro.Core;

public static class AbpProApplicationExtensions
{

    public static IApplicationBuilder UseAbpProRequestLocalization(this IApplicationBuilder app)
    {
        return app.UseAbpRequestLocalization(options =>
        {
            options.RequestCultureProviders.RemoveAll(provider => provider is AcceptLanguageHeaderRequestCultureProvider);

            options.RequestCultureProviders.Add(new AbpProCultureProvider());

        });
    }

    public static IApplicationBuilder UseAbpProSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        var authOptions = configuration.GetOptions<AuthServerOptions>();

        var globalOptions = configuration.GetOptions<GlobalOptions>();

        app.UseSwagger();

        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint(AbpProCoreConsts.Swagger.JsonEndpoint, AbpProCoreConsts.Swagger.ApiTitle);

            options.OAuthClientId(authOptions.SwaggerClientId);

            options.OAuthScopes(globalOptions.Scopes);
        });

        return app;
    }

    public static IApplicationBuilder UseAbpProMultiTenancy(this IApplicationBuilder app, IConfiguration configuration)
    {
        var multiTenancyOptions = configuration.GetOptions<MultiTenancyOptions>();

        if (multiTenancyOptions.Enabled)
        {
            app.UseMultiTenancy();
        }

        return app;

    }

}
