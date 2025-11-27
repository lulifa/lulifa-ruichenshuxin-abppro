namespace RuichenShuxin.AbpPro.Platform;

public class MenuGetAllInput : ISortedResultRequest
{
    [DynamicStringLength(typeof(AbpProCoreConsts), nameof(AbpProCoreConsts.MaxLength64))]
    public string Framework { get; set; }

    public string Filter { get; set; }

    public bool Reverse { get; set; }

    public Guid? ParentId { get; set; }

    public string Sorting { get; set; }

    public Guid? LayoutId { get; set; }
}
