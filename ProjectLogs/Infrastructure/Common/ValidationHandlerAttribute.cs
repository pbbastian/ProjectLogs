using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLogs.Infrastructure.Common
{
    public class ValidationHandlerAttribute : Attribute
    {
        public Type InputType { get; private set; }

        public ValidationHandlerAttribute(Type inputType)
        {
            InputType = inputType;
        }
    }
}