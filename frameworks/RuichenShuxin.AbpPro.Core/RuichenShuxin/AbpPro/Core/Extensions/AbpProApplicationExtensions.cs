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

        app.UseSwagger();

        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint(AbpProCoreConsts.Swagger.JsonEndpoint, AbpProCoreConsts.Swagger.ApiTitle);

            options.OAuthClientId(authOptions.SwaggerClientId);

            options.OAuthScopes(authOptions.Scopes);
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
