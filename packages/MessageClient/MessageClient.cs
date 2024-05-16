namespace MessageClient;

using EasyNetQ;

public class MessageClient
{
    private readonly IBus _bus;
    
    public static MessageClient Create(string connectionString)
    {
        var bus = RabbitHutch.CreateBus(connectionString);
        return new MessageClient(bus);
    }
    
    public MessageClient(IBus bus)
    {
        _bus = bus;
    }

    public MessageClient()
    {
        
    }

    public virtual void Send<T>(T message, string topic)
    {
        _bus.PubSub.Publish(message, topic);
    }

    public void Listen<T>(Action<T> handler, string topic)
    {
        _bus.PubSub.Subscribe(topic, handler);
    }
}