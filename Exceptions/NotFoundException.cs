using System;
using System.Collections.Generic;

namespace CustomerApi.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(Exception ex) : base(ex, 404)
        {
        }

        public NotFoundException(string message) : base(message, 404)
        {
        }
    }
}