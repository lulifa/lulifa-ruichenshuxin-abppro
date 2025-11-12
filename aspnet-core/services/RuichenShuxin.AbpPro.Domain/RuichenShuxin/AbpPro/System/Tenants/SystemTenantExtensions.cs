namespace RuichenShuxin.AbpPro;

public static class SystemTenantExtensions
{
    public static bool GetIsActive(this Tenant tenant)
    {
        return tenant.GetProperty<bool>("IsActive");
    }

    public static void SetIsActive(this Tenant tenant, bool isActive)
    {
        tenant.SetProperty("IsActive", isActive);
    }

    public static DateTime? GetEnableTime(this Tenant tenant)
    {
        return tenant.GetProperty<DateTime?>("EnableTime");
    }

    public static void SetEnableTime(this Tenant tenant, DateTime? enableTime)
    {
        tenant.SetProperty("EnableTime", enableTime);
    }

    public static DateTime? GetDisableTime(this Tenant tenant)
    {
        return tenant.GetProperty<DateTime?>("DisableTime");
    }

    public static void SetDisableTime(this Tenant tenant, DateTime? disableTime)
    {
        tenant.SetProperty("DisableTime", disableTime);
    }
}
