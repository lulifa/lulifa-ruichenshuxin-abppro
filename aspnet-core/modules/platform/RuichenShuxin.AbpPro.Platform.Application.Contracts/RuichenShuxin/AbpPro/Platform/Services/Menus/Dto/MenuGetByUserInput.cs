namespace RuichenShuxin.AbpPro.Platform;

public class MenuGetByUserInput
{
    [Required]
    public Guid UserId { get; set; }

    public string[] Roles { get; set; } = Array.Empty<string>();

    [DynamicStringLength(typeof(PlatformConsts), nameof(PlatformConsts.MaxLength64))]
    public string Framework { get; set; }
}
