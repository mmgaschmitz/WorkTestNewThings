
namespace ConsoleAppDepInjection.DepenWithServiceProvider
{
    internal class Application
    {
        Depend.IMessageWriter _messagewriter;
        public Application(Depend.IMessageWriter messagewriter)
        {
            _messagewriter = messagewriter;
        }

        public void RunIt()
        {
            Depend.Worker work3 = new Depend.Worker(_messagewriter);
            work3.DoSomething("actie4");
            // Do something epic}
        }
    }
}
