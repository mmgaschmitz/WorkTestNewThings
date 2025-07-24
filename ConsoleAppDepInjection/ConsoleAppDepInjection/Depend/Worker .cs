using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDepInjection.Depend
{
    public class Worker
    {
        private readonly IMessageWriter _messageWriter;
        public Worker(IMessageWriter messageWriter)
        {
            _messageWriter = messageWriter;
        }
        public void DoSomething(string action)
        {

            _messageWriter.Write(action);

        }
    }
}
