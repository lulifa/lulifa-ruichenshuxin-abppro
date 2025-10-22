using Microsoft.Extensions.Configuration;

namespace RuichenShuxin.AbpPro.Core;

public static class AbpProConfigurationExtensions
{
    public static void BindOptions<T>(this IConfiguration configuration, T options, string sectionName = null) where T : class
    {
        sectionName ??= typeof(T).Name.Replace("Options", "");
        configuration.GetSection(sectionName).Bind(options);
    }


    public static T GetOptions<T>(this IConfiguration configuration, string sectionName = null) where T : new()
    {
        sectionName ??= typeof(T).Name.Replace("Options", "");

        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }
}
