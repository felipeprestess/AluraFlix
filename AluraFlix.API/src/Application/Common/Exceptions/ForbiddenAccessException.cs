using System;

namespace AluraFlix.API.Application.Common.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException() : base() { }
    }
}
