using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DemoDispatchProxy
{
    public class LoggingDecoratorProxy<T> : DispatchProxy
    {
        private readonly Logger _logger;
        public T Target { get; internal set; }

        public LoggingDecoratorProxy() : base()
        {
            _logger = new Serilog.LoggerConfiguration()
                .WriteTo.Console().CreateLogger(); // used serilog
        }

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            try
            {
                _logger.Information("{TypeName}.{MethodName}({Arguments})", targetMethod.DeclaringType.Name, targetMethod.Name, args);

                if (targetMethod.DeclaringType.Name == "IEmailMessageSender" && targetMethod.Name == "TrySendMessage")
                {
                    Console.WriteLine("Voor de call, het mail adres " + (string) args[0]);
                }

                var result = targetMethod.Invoke(Target, args);

                if (targetMethod.DeclaringType.Name == "IEmailMessageSender" && targetMethod.Name == "TrySendMessage")
                {
                    Console.WriteLine("Na de call, het mail adres }" + (string) args[0]);
                    Console.WriteLine("Extra log result" + ((bool) result).ToString());
                }


                _logger.Information("{TypeName}.{MethodName} returned -> {ReturnValue}", targetMethod.DeclaringType.Name, targetMethod.Name, result);

                return result;
            }
            catch (TargetInvocationException exc)
            {

                _logger.Warning(exc.InnerException, "{TypeName}.{MethodName} threw exception: {Exception}", targetMethod.DeclaringType.Name, targetMethod.Name, exc.InnerException);
                throw exc.InnerException;
            }
        }
    }
}
