namespace RuichenShuxin.AbpPro.Core;

public class AbpProCoreDataSeedBackgroundWorker : BackgroundService
{
    protected IDataSeeder DataSeeder { get; }
    public AbpProCoreDataSeedBackgroundWorker(IDataSeeder dataSeeder)
    {
        DataSeeder = dataSeeder;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DataSeeder.SeedAsync();
    }
}
