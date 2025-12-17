using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace RuichenShuxin.AbpPro.DataProtectionManagement.EntityFrameworkCore;

[ConnectionStringName(DataProtectionManagementDbProperties.ConnectionStringName)]
public interface IDataProtectionManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
