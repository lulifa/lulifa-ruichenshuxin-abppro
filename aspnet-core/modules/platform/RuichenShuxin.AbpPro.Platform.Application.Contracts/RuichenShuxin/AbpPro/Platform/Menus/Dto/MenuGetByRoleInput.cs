namespace RuichenShuxin.AbpPro.Platform;

public class MenuGetByRoleInput
{
    [Required]
    [StringLength(80)]
    public string Role { get; set; }

    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength64))]
    public string Framework { get; set; }
}
