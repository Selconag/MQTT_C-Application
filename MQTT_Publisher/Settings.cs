using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTTPublisher;

public record Settings
{
    private string tcpServerAdress = "test.mosquitto.org";
    private string clientID = Guid.NewGuid().ToString();

    public Settings GetSettings
    {
        get { return this; }
    }

    public string GetActiveTCPAdress
    {
        get { return tcpServerAdress; }
        private set { tcpServerAdress = value; }
    }
    public string GetClientID
    {
        get { return clientID; }
        private set { clientID = value; }
    }
}
