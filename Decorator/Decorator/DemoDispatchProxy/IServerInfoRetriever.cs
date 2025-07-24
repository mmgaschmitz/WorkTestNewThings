using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DemoDispatchProxy
{
    public interface IServerInfoRetriever
    {
        public ServerInfo GetInfo(IPAddress address);
    }
}
