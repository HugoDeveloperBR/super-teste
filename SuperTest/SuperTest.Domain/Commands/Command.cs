using System.Collections.Generic;

namespace SuperTest.Domain.Commands
{
    public abstract class Command 
    {
        public Command()
        {
            Notifications = new List<string>();
        }

        public abstract bool IsValid();
        public List<string> Notifications { get; set; }
    }
}
