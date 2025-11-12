namespace RuichenShuxin.AbpPro;

public abstract class TenantCreateOrUpdateBase : ExtensibleObject
{
    [Required]
    [DynamicStringLength(typeof(TenantConsts), nameof(TenantConsts.MaxNameLength))]

    public string Name { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime? EnableTime { get; set; }

    public DateTime? DisableTime { get; set; }

}
