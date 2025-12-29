using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDepInjection
{
    public class Worker
    {
        private readonly MessageWriter _messageWriter = new();

        public void DoSomething(string action)
        {

            _messageWriter.Write(action);

        }
    }
}
