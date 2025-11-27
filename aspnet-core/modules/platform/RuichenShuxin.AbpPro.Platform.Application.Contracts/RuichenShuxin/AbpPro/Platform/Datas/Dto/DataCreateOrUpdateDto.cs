namespace RuichenShuxin.AbpPro.Platform;

public class DataCreateOrUpdateDto
{
    [Required]
    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength64))]
    public string Name { get; set; }

    [Required]
    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength128))]
    public string DisplayName { get; set; }

    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength1024))]
    public string Description { get; set; }
}
