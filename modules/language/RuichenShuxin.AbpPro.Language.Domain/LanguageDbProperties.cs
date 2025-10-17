namespace RuichenShuxin.AbpPro.Language;

public static class LanguageDbProperties
{
    public static string DbTablePrefix { get; set; } = "Language";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Language";
}
