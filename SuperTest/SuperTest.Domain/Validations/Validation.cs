using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTest.Domain.Validations
{
    public abstract class Validation
    {
        public abstract Result IsValid();
    }
}
