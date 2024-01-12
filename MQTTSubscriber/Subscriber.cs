using MQTTnet.Client;
using MQTTnet;
using System.Text;
using MQTTnet.Server;
using System.Text.Json;
namespace MQTTSubscriber;

public class Subscriber
{
    static async Task Main(string[] args)
    {
        var mqttFactory = new MqttFactory();
        IMqttClient client = mqttFactory.CreateMqttClient();
        Settings settings = new Settings();
        //Build it first
        var options = mqttFactory.CreateClientOptionsBuilder()
            .WithClientId(settings.GetClientID)
            .WithTcpServer(settings.GetActiveTCPAdress, 1883)
            .WithCleanSession()
            .Build();



        client.UseConnectedHandler(async e =>
        {
            Console.WriteLine("Connected to the Broker Succesfully");
            var topicFilter = new TopicFilterBuilder()
            .WithTopic("Houston")
            .Build();
            await client.SubscribeAsync(topicFilter);
        });

        client.UseDisconnectedHandler(e =>
        {
            Console.WriteLine("Disconnected to the Broker Succesfully");
        });

        client.UseApplicationMessageReceivedHandler(e =>
        {
            Console.WriteLine($"Received Message: {e.ApplicationMessage.Topic}- {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
        
        });

        await client.ConnectAsync(options);

        Console.ReadLine();

        await client.DisconnectAsync();

    }
}
