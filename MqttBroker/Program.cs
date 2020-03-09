using MQTTnet;
using MQTTnet.Server;
using System;

namespace MqttBroker
{
    class Program
    {
        static void Main(string[] args)
        {
            InitMqtt();   
        }
        static async void InitMqtt()
        {
            // Start a MQTT server.
            Console.WriteLine("Starting MQTT Server at: localhost:1883");
            // Configure MQTT server.
            var optionsBuilder = new MqttServerOptionsBuilder()
                .WithConnectionBacklog(100)
                .WithDefaultEndpointPort(1883);

            var mqttServer = new MqttFactory().CreateMqttServer();
            await mqttServer.StartAsync(optionsBuilder.Build());
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
            await mqttServer.StopAsync();
        }
    }
}
