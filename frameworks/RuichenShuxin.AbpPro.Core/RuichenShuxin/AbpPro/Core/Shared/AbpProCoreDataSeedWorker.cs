namespace RuichenShuxin.AbpPro.Core;

public class AbpProCoreDataSeedWorker : BackgroundService
{
    protected IDataSeeder DataSeeder { get; }
    public AbpProCoreDataSeedWorker(IDataSeeder dataSeeder)
    {
        DataSeeder = dataSeeder;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DataSeeder.SeedAsync();
    }
}
