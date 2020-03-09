using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace BlazorMqttClient.Data
{
    public class MqttClientService
    { 
        private IMqttClient MqttClient;
        public event EventHandler MessageRecievedHandler;
        
        public MqttClientService()
        {
            var factory = new MqttFactory();
            MqttClient = factory.CreateMqttClient();
        }

        public async Task<bool> ConnectAsync()
        {
            var options = new MqttClientOptionsBuilder()
                .WithClientId("blazor-mqttclient")
                .WithTcpServer("localhost", 1883)
                .Build();
            await MqttClient.ConnectAsync(options);
            return MqttClient.IsConnected;
        }

        public async void Subscribe()
        {
            var topicBuilder = new TopicFilterBuilder()
                .WithTopic("test/messages")
                .Build();
            await MqttClient.SubscribeAsync(topicBuilder);
            MqttClient.UseApplicationMessageReceivedHandler(e =>
            {
                MessageRecievedHandler(this, e);
            });
        }
    }
}
