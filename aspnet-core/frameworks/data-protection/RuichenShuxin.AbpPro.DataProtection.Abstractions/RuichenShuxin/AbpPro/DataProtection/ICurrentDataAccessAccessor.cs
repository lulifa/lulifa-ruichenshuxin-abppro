namespace RuichenShuxin.AbpPro.DataProtection.Abstractions;

public interface ICurrentDataAccessAccessor
{
    DataAccessOperation[] Current { get; set; }
}
