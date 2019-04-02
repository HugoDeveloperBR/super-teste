using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTest.Domain.Helpers
{
    public interface INotification
    {
        List<string> Notifications { get; set; }
        bool HasNotification { get; }
        void AddNotification(string notification);
        void Clear();
    }
}
