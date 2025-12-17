using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace RuichenShuxin.AbpPro.DataProtectionManagement.EntityFrameworkCore;

[ConnectionStringName(DataProtectionManagementDbProperties.ConnectionStringName)]
public class DataProtectionManagementDbContext : AbpDbContext<DataProtectionManagementDbContext>, IDataProtectionManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public DataProtectionManagementDbContext(DbContextOptions<DataProtectionManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureDataProtectionManagement();
    }
}
