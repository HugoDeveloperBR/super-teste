using System;

namespace SuperTest.Domain.Events
{
    public class EventStore : Event
    {
        public EventStore(Event @event, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = @event.AggregateId;
            MessageType = @event.MessageType;
            Data = data;
            user = user;
        }

        protected EventStore() { }

        public Guid Id { get; private set; }
        public string Data { get; private set; }
        public string Usuario { get; private set; }
    }
}
