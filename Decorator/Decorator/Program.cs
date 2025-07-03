
// See https://aka.ms/new-console-template for more information

//
// https://dev.to/kalkwst/decorator-pattern-in-c-5ddc
//
using Decorator.Components;
using Decorator.Decorators;
using Decorator.DemoDispatchProxy;
using System.Net;

Console.WriteLine("Hello, World!");


Salad salade= new("groeten", "kaas", "saus");
salade.Display();

Pasta pasta = new("mijn past", "past saus");
pasta.Display();

// abstract kan geen instance van 
// Dish dish = new();

// abstract kan geen instance van 
// AbstractDecorator abstractDecorator = new(salade);

AvailabilityDecorator caesarAvailability = new(salade, 3);
AvailabilityDecorator pastaAvailability = new(pasta, 4);

caesarAvailability.OrderItem("Marion");
caesarAvailability.OrderItem("Thomas");
caesarAvailability.OrderItem("Imogen");
caesarAvailability.OrderItem("Jude");

pastaAvailability.OrderItem("Marion");
pastaAvailability.OrderItem("Thomas");
pastaAvailability.OrderItem("Imogen");
pastaAvailability.OrderItem("Jude");
pastaAvailability.OrderItem("Jacinth");

caesarAvailability.Display();
pastaAvailability.Display();
caesarAvailability.DisplayMore();
pastaAvailability.DisplayMore();



//
// https://dev.to/rasulhsn/example-of-aspect-oriented-paradigm-by-dynamically-decorating-objects-with-dispatchproxy-class-3l7
// DispatchProxy
//


var mailSender = new EmailMessageSender();
mailSender.TrySendMessage("tuup", "helll", "say something");

var serverInfoRetr = new ServerInfoRetriever();
serverInfoRetr.GetInfo(IPAddress.Parse("127.0.0.1"));

// met proxy.
IEmailMessageSender emailSender = LoggingDecoratorProxyFactory.Create<IEmailMessageSender, EmailMessageSender>(new EmailMessageSender());
emailSender.TrySendMessage("resulhsn@gmail.com", "Test", "Hi Rasul");

Console.WriteLine("------------------------------------------------------------------------------------------");

IServerInfoRetriever retriever = LoggingDecoratorProxyFactory.Create<IServerInfoRetriever, ServerInfoRetriever>(new ServerInfoRetriever());
retriever.GetInfo(IPAddress.Parse("127.0.0.1"));