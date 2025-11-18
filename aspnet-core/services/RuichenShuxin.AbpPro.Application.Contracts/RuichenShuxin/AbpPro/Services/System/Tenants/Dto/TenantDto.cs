namespace RuichenShuxin.AbpPro;

public class TenantDto : ExtensibleAuditedEntityDto<Guid>, IHasConcurrencyStamp
{
    public string Name { get; set; }

    public string NormalizedName { get; set; }

    public bool IsActive { get; set; }

    public DateTime? EnableTime { get; set; }

    public DateTime? DisableTime { get; set; }

    public string ConcurrencyStamp { get; set; }

}