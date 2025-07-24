using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DemoDispatchProxy
{
    public interface IEmailMessageSender
    {
        public bool TrySendMessage(string to, string subject, string message);
    }
}
