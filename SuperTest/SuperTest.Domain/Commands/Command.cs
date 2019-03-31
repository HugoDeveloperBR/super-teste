using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTest.Domain.Commands
{
    public abstract class Command
    {
        public Result ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
