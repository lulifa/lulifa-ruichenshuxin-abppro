namespace RuichenShuxin.AbpPro.Core;

public class AppOptions
{
    public string SelfUrl { get; set; }
    public string AngularUrl { get; set; }
    public string CorsOrigins { get; set; }
    public string RedirectAllowedUrls { get; set; }
    public bool DisablePII { get; set; }
    public string HealthCheckUrl { get; set; }
}
