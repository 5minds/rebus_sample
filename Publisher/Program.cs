using System;

namespace Rebus.Publisher
{
    using System.Threading.Tasks;
    using Domain;
    using Rebus.Activation;
    using Rebus.Config;
    using Rebus.Routing.TypeBased;

    class Program
    {
        private const string ConnectionString = "amqp://guest:guest@localhost:5672/";
        public async static Task Main()
        {
            using(var activator = new BuiltinHandlerActivator())
            {
                var publisher = Configure.With(activator)
                    .Transport(t => t.UseRabbitMqAsOneWayClient(ConnectionString))
                    .Routing(r => r.TypeBased().MapAssemblyOf<TakeOutTrashMessage>("Household"))
                    .Start();

                while(true)
                {
                    await publisher.Send(new TakeOutTrashMessage());
                    await publisher.Send(new EmptyDishwasherMessage());
                    Console.WriteLine("Press 'q' to quit or any other key to send another message.");
                    if (Console.ReadKey().KeyChar == 'q')
                    {
                        break;
                    }
                }
            }
        }
    }
}
