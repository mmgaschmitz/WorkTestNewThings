using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DemoDispatchProxy
{
    public class ServerInfoRetriever : IServerInfoRetriever
    {
        // Simulation
        public ServerInfo GetInfo(IPAddress address)
        {
            Console.WriteLine($"{address.ToString()} Server Info Retrieved!");
            return new ServerInfo("In process", DateTime.Now, "1.0.0"); // fake info
        }
    }
}
