namespace WhitelistService;

public sealed class ConnectionString
{
    public string Value { get; set; }
}

public sealed class Settings
{
    public ConnectionString RabbitMqConnectionString { get; set; }
}