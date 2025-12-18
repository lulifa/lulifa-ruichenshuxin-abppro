
namespace RuichenShuxin.AbpPro.EntityFrameworkCore;

public class AbpProDbContext : AbpProDataProtectionDbContext<AbpProDbContext>, IAbpProDbContext
{

    public DbSet<Book> Books { get; set; }

    public AbpProDbContext(DbContextOptions<AbpProDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePlatform();

        builder.ConfigureAbpPro();
    }
}
