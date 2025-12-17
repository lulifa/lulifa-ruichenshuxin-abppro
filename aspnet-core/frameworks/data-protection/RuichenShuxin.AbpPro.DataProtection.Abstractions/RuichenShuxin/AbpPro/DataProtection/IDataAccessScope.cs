namespace RuichenShuxin.AbpPro.DataProtection.Abstractions;

public interface IDataAccessScope
{
    DataAccessOperation[] Operations { get; }
    IDisposable BeginScope(DataAccessOperation[] operations = null);
}
