using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDepInjection.Depend
{
    public class MessageWriterTwo : IMessageWriter
    {
        public void Write(string message)
        {
            Console.WriteLine($"MessageWriter.Write(messageTwo: \"{message}\")");
        }
    }
}
