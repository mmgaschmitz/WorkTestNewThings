using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DemoDispatchProxy
{
   public class EmailMessageSender : IEmailMessageSender
    {
        // Simulation
        public bool TrySendMessage(string to, string subject, string message)
        {
            Console.WriteLine($"Message sent to the {to}");
            return true; // fake info
        }
    }
}
