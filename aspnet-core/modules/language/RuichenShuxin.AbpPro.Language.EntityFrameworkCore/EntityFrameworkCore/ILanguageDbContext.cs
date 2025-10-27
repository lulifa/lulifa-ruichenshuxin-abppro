using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace RuichenShuxin.AbpPro.Language.EntityFrameworkCore;

[ConnectionStringName(LanguageDbProperties.ConnectionStringName)]
public interface ILanguageDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
