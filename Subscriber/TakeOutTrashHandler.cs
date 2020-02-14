namespace Rebus.Subscriber
{
    using System;
    using System.Threading.Tasks;
    using Domain;
    using Rebus.Handlers;

    public class TakeOutTrashHandler : IHandleMessages<TakeOutTrashMessage>
    {
        public Task Handle(TakeOutTrashMessage message)
        {
            Console.WriteLine("Jaja");

            return Task.CompletedTask;
        }
    }
}