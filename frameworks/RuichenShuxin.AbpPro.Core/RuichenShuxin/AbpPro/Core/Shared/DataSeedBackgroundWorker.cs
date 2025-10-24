using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Data;

namespace RuichenShuxin.AbpPro.Core;

public class DataSeedBackgroundWorker : BackgroundService
{
    protected IDataSeeder DataSeeder { get; }
    public DataSeedBackgroundWorker(IDataSeeder dataSeeder)
    {
        DataSeeder = dataSeeder;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DataSeeder.SeedAsync();
    }
}
