namespace RuichenShuxin.AbpPro.Core;

public class PlatformCapOptions
{
    public bool IsEnabled { get; set; }

    public CAPEventBusOptions EventBus { get; set; }

    public CAPRabbitMQOptions RabbitMQ { get; set; }

    public CAPRedisOptions Redis { get; set; }

}

public class CAPEventBusOptions
{
    public string DefaultGroupName { get; set; }

    public string GroupNamePrefix { get; set; }

    public string Version { get; set; }

    public int FailedRetryInterval { get; set; }

    public int FailedRetryCount { get; set; }

    public bool NotifyFailedCallback { get; set; }

}

public class CAPRabbitMQOptions
{
    public string HostName { get; set; }

    public int Port { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string ExchangeName { get; set; }

    public string VirtualHost { get; set; }
}

public class CAPRedisOptions
{
    public string Configuration { get; set; }
}
