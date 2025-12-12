namespace RuichenShuxin.AbpPro.Core;

public class AbpTenantConnectionStringCheckOptions
{
    public IDictionary<string, IDataBaseConnectionStringChecker> ConnectionStringCheckers { get; }

    public AbpTenantConnectionStringCheckOptions()
    {
        ConnectionStringCheckers = new Dictionary<string, IDataBaseConnectionStringChecker>(StringComparer.InvariantCultureIgnoreCase);
    }
}
