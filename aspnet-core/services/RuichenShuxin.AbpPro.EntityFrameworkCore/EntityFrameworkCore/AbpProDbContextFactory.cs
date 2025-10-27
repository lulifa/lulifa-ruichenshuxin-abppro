namespace RuichenShuxin.AbpPro.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AbpProDbContextFactory : IDesignTimeDbContextFactory<AbpProDbContext>
{
    public AbpProDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AbpProEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AbpProDbContext>()
            .UseMySQL(configuration.GetConnectionString("Default"));
        
        return new AbpProDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../RuichenShuxin.AbpPro.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
