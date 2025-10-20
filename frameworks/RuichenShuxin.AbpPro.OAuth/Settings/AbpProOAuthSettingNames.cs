namespace RuichenShuxin.AbpPro.OAuth;

public class AbpProOAuthSettingNames
{
    public const string GroupName = "AbpPro.OAuth";

    public static class GitHub
    {
        public const string Prefix = GroupName + ".GitHub";

        /// <summary>
        /// 是否启用
        /// </summary>
        public const string IsEnabled = Prefix + ".IsEnabled";
        /// <summary>
        /// ClientId
        /// </summary>
        public const string ClientId = Prefix + ".ClientId";
        /// <summary>
        /// ClientSecret
        /// </summary>
        public const string ClientSecret = Prefix + ".ClientSecret";
    }

    public static class Gitee
    {
        public const string Prefix = GroupName + ".Gitee";
        /// <summary>
        /// 是否启用
        /// </summary>
        public const string IsEnabled = Prefix + ".IsEnabled";
        /// <summary>
        /// ClientId
        /// </summary>
        public const string ClientId = Prefix + ".ClientId";
        /// <summary>
        /// ClientSecret
        /// </summary>
        public const string ClientSecret = Prefix + ".ClientSecret";
    }

    public static class Bilibili
    {
        public const string Prefix = GroupName + ".Bilibili";
        /// <summary>
        /// 是否启用
        /// </summary>
        public const string IsEnabled = Prefix + ".IsEnabled";
        /// <summary>
        /// ClientId
        /// </summary>
        public const string ClientId = Prefix + ".ClientId";
        /// <summary>
        /// ClientSecret
        /// </summary>
        public const string ClientSecret = Prefix + ".ClientSecret";
    }
}
