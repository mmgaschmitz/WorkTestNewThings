using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppDepInjection.DepenWithServiceProvider
{
    internal class ProgramSetup
    {
        internal static ServiceProvider CreateServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<Application,Application>()
                .AddSingleton<Depend.IMessageWriter, Depend.MessageWriterTwo>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
