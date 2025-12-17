namespace RuichenShuxin.AbpPro.DataProtection.Abstractions;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
public class DisableDataProtectedAttribute : Attribute
{
    public DisableDataProtectedAttribute()
    {
    }
}
