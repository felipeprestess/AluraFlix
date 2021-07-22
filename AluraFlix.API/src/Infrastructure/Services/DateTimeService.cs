using AluraFlix.API.Application.Common.Interfaces;
using System;

namespace AluraFlix.API.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
