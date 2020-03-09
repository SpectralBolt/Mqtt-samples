using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMqttClient.Models
{
    public class Message
    {
        public string ClientId { get; set; }
        public string Payload { get; set; }
        public string Topic { get; set; }
    }
}
