namespace WhitelistService;

public sealed class ConnectionString
{
    public string Value { get; }
}

public class Settings
{
    public ConnectionString RabbitMqConnectionString { get; set; }
}