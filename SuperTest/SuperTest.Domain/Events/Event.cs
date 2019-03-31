using MediatR;
using System;

namespace SuperTest.Domain.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected  Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
