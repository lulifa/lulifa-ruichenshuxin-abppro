namespace RuichenShuxin.AbpPro.Platform;

public abstract class UserFavoriteMenuCreateOrUpdateDto
{
    [Required]
    public Guid MenuId { get; set; }

    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength64))]
    public string Color { get; set; }

    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength128))]
    public string AliasName { get; set; }

    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength512))]
    public string Icon { get; set; }
}
