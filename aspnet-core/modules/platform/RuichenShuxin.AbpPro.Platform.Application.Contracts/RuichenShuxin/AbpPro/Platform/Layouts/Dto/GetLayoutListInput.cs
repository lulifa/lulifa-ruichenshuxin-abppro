namespace RuichenShuxin.AbpPro.Platform;

public class GetLayoutListInput : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }

    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength64))]
    public string Framework { get; set; }
}
