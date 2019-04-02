using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SuperTest.ApplicationService
{
    public abstract class AppServiceBase : IDisposable
    {
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public AppServiceBase()
        {
            Notifications = new List<string>();
        }

        #region Notification

        public List<string> Notifications { get; set; }

        public bool HasNotification
        {
            get
            {
                return Notifications.Any();
            }
        }

        public void Clear()
        {
            Notifications.Clear();
        }

        public void AddNotification(string notification)
        {
            Notifications.Add(notification);
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                handle.Dispose();

            disposed = true;
        }
    }
}