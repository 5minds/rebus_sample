using System;

namespace Rebus.Subscriber
{
    using System.Threading.Tasks;
    using Rebus.Activation;
    using Rebus.Config;
    class Program
    {
        private const string ConnectionString = "amqp://guest:guest@localhost:5672/";
        public async static Task Main()
        {
            using(var activator = new BuiltinHandlerActivator())
            {
                activator.Register(() => new TakeOutTrashHandler());
                activator.Register(() => new EmptyDishwasherHandler());

                var subscriber = Configure
                    .With(activator)
                    .Transport(t => t.UseRabbitMq(ConnectionString, "Household"))
                    .Start();

                await subscriber.Subscribe<Domain.TakeOutTrashMessage>();
                await subscriber.Subscribe<Domain.EmptyDishwasherMessage>();
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
