using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DemoDispatchProxy
{
    public static class LoggingDecoratorProxyFactory
    {
        public static TInterface Create<TInterface, TConcrete>(TConcrete instance) where TConcrete : class, TInterface where TInterface : class
        {
            if (!typeof(TInterface).IsInterface)
                throw new Exception($"{typeof(TInterface).Name} must be interface!");

            LoggingDecoratorProxy<TInterface> proxy = LoggingDecoratorProxy<TInterface>.Create<TInterface, LoggingDecoratorProxy<TInterface>>()
                        as LoggingDecoratorProxy<TInterface>;

            proxy.Target = instance;
            return proxy as TInterface;
        }
    }
}
