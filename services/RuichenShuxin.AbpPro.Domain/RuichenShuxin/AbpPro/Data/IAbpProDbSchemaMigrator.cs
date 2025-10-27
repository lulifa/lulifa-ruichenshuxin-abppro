using System.Threading.Tasks;

namespace RuichenShuxin.AbpPro;

public interface IAbpProDbSchemaMigrator
{
    Task MigrateAsync();
}
