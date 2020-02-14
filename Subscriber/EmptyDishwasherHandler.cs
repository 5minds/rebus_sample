namespace Rebus.Subscriber
{
    using System;
    using System.Threading.Tasks;
    using Domain;
    using Rebus.Handlers;

    public class EmptyDishwasherHandler : IHandleMessages<EmptyDishwasherMessage>
    {
        public Task Handle(EmptyDishwasherMessage message)
        {
            Console.WriteLine("Das bisschen Haushalt macht sich von allein");

            return Task.CompletedTask;
        }
    }
}