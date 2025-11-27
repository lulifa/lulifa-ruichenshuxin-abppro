namespace RuichenShuxin.AbpPro.Platform;

public class GetDataByNameInput
{
    [Required]
    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength64))]
    public string Name { get; set; }
}
