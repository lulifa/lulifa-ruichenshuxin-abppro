using System.Threading.Tasks;

namespace RuichenShuxin.AbpPro.Data;

public interface IAbpProDbSchemaMigrator
{
    Task MigrateAsync();
}
