// See https://aka.ms/new-console-template for more information
using ConsoleAppDepInjection;
using ConsoleAppDepInjection.DepenWithServiceProvider;
using Microsoft.Extensions.DependencyInjection;
using Application = ConsoleAppDepInjection.DepenWithServiceProvider.Application;
using Depend = ConsoleAppDepInjection.Depend;



Console.WriteLine("Hello, World!");


// Geen depency injection
Worker work1 = new();

work1.DoSomething("Hello");
work1.DoSomething("Hello2");


// Zelf de depency vullen

Depend.Worker work2 = new Depend.Worker(new Depend.MessageWriter());
work2.DoSomething("actie3");

Depend.Worker work3 = new Depend.Worker(new Depend.MessageWriterTwo());
work3.DoSomething("actie4");


// Dependency injection zoals bij servces
// de service
var services = ProgramSetup.CreateServices();
// de logica
Application app = services.GetRequiredService<Application>();
app.RunIt();




