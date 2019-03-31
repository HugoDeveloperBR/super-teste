using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperTest.ApplicationService
{
    public abstract class AppServiceBase : IDisposable
    {
        public AppServiceBase()
        {
            Notifications = new List<string>();
        }

        public List<string> Notifications { get; set; }

        public bool HasNotification
        {
            get
            {
                return Notifications.Any();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
