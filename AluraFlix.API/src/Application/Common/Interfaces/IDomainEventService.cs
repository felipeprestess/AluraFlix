using AluraFlix.API.Domain.Common;
using System.Threading.Tasks;

namespace AluraFlix.API.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
