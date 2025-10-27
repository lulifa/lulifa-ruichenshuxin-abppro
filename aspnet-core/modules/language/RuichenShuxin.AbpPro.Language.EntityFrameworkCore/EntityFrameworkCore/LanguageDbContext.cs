using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace RuichenShuxin.AbpPro.Language.EntityFrameworkCore;

[ConnectionStringName(LanguageDbProperties.ConnectionStringName)]
public class LanguageDbContext : AbpDbContext<LanguageDbContext>, ILanguageDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public LanguageDbContext(DbContextOptions<LanguageDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureLanguage();
    }
}
