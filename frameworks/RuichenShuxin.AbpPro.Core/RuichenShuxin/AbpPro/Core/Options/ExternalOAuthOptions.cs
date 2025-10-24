namespace RuichenShuxin.AbpPro.Core;

public class ExternalOAuthOptions
{
    public ExternalOAuth GitHub { get; set; } = new();
    public ExternalOAuth Gitee { get; set; } = new();
    public ExternalOAuth Bilibili { get; set; } = new();

}

public class ExternalOAuth
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}
