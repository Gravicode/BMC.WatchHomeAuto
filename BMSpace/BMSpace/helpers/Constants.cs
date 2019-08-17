using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMSpace.helpers
{
    public class CONSTANTS
    {
        public const string IPBrokerAddress = "110.35.82.86"; //ConfigurationManager.AppSettings["MqttHost"];azure - 13.76.156.239";// 
        public const string ClientUser = "loradev_mqtt"; //ConfigurationManager.AppSettings["MqttUser"];
        public const string ClientPass = "test123";//ConfigurationManager.AppSettings["MqttPass"];
        public const string clientId = "bmc-gateway-2";//Guid.NewGuid().ToString();
    }
}
