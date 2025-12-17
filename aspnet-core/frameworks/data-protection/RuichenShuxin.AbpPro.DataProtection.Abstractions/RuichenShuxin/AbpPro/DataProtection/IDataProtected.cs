namespace RuichenShuxin.AbpPro.DataProtection.Abstractions;

public interface IDataProtected
{
    Guid? CreatorId { get; }
}