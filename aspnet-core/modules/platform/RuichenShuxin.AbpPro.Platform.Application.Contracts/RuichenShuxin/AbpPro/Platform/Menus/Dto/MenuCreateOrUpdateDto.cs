namespace RuichenShuxin.AbpPro.Platform;

public class MenuCreateOrUpdateDto
{
    public Guid? ParentId { get; set; }

    [Required]
    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength64))]
    public string Name { get; set; }

    [Required]
    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength128))]
    public string DisplayName { get; set; }

    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength256))]
    public string Description { get; set; }

    [Required]
    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength256))]
    public string Path { get; set; }

    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength256))]
    public string Redirect { get; set; }

    [Required]
    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength256))]
    public string Component { get; set; }

    public bool IsPublic { get; set; }

    public Dictionary<string, object> Meta { get; set; } = new Dictionary<string, object>();
}
