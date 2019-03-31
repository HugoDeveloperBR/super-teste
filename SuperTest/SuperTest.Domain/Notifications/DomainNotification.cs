using SuperTest.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTest.Domain.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
    }
}
