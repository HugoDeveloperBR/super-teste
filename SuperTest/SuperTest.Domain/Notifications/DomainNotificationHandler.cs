using MediatR;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperTest.Domain.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notificatons;

        public DomainNotificationHandler()
        {
            _notificatons = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _notificatons.Add(notification);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotification()
        {
            return _notificatons;
        }

        public virtual bool HasNotification()
        {
            return GetNotification().Any();
        }

        public void Dispose()
        {
            _notificatons = new List<DomainNotification>();
        }
    }
}
