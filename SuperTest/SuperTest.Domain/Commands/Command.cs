using SuperTest.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTest.Domain.Commands
{
    public abstract class Command : Message
    {
        public Result ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
