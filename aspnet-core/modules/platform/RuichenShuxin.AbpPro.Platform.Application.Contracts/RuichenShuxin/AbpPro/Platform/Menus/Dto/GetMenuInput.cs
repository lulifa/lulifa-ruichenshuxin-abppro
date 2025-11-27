namespace RuichenShuxin.AbpPro.Platform;

public class GetMenuInput
{
    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength64))]
    public string Framework { get; set; }
}
