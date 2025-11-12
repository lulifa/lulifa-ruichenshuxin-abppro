namespace RuichenShuxin.AbpPro.Core;

public static class AbpProCoreConsts
{
    /// <summary>
    /// 应用名称
    /// </summary>
    public const string ApplicationName = "AbpPro";

    /// <summary>
    /// Wrap
    /// </summary>
    public const string AbpWrapResult = "_AbpWrapResult";


    public static int MaxLength64 { get; set; } = 64;
    public static int MaxLength128 { get; set; } = 128;
    public static int MaxLength256 { get; set; } = 256;
    public static int MaxLength512 { get; set; } = 512;
    public static int MaxLength1024 { get; set; } = 1024;


    /// <summary>
    /// URL相关常量
    /// </summary>
    public static class Urls
    {
        public const string PasswordReset = "Abp.Account.PasswordReset";
        public const string EmailConfirmation = "Abp.Account.EmailConfirmation";
    }

    /// <summary>
    /// 多语言相关常量
    /// </summary>
    public static class Languages
    {
        public const string ZhHans = "zh-Hans";
        public const string EN = "en";
    }

    /// <summary>
    /// Swagger相关常量
    /// </summary>
    public static class Swagger
    {
        public const string ApiTitle = $"{ApplicationName} API";
        public const string Version = "v1";
        public const string JsonEndpoint = $"/swagger/{Version}/swagger.json";
    }

    /// <summary>
    /// 缓存相关常量
    /// </summary>
    public static class Cache
    {
        public const string KeyPrefix = $"{ApplicationName}:";
    }

}
