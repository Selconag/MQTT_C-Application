using System.Diagnostics;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;

namespace MQTTPublisher;

public class Publisher
{
    static async Task Main(string[] args)
    {
        var mqttFactory = new MqttFactory();
        IMqttClient client = mqttFactory.CreateMqttClient();

        //Build it first
        var options = mqttFactory.CreateClientOptionsBuilder()
            .WithClientId(Guid.NewGuid().ToString())
            .WithTcpServer("test.mosquitto.org" , 1883)
            .WithCleanSession()
            .Build();


        client.UseConnectedHandler(e =>
        {
            Console.WriteLine("Connected to the Broker Succesfully");
        });

        client.UseDisconnectedHandler(e =>
        {
            Console.WriteLine("Disconnected to the Broker Succesfully");
        });

        await client.ConnectAsync(options);

        Console.WriteLine($"Houston we have a connection\n");
        Console.WriteLine($"Houston press a key or something!\n");
        Console.ReadLine();

        await PublishMessageAsync(client);

        await client.DisconnectAsync();

    }

    private static async Task PublishMessageAsync(IMqttClient client)
    {
        string messagePayload = "What!";
        var message = new MqttApplicationMessageBuilder()
            .WithTopic("Houston")
            .WithPayload(messagePayload)
            .WithAtLeastOnceQoS()
            .Build();
        if (client.IsConnected)
        {
            await client.PublishAsync(message);
            Console.WriteLine($"Published Message: {message}");

        }
    }

    public void ConnectionMessagePublish(MqttClientConnectionStatus status)
    {
        Debug.WriteLine($"Houston we have a {status}");
    }
}

