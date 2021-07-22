using AluraFlix.API.Application.Common.Models;
using AluraFlix.API.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AluraFlix.API.Application.TodoItems.EventHandlers
{
    public class TodoItemCreatedEventHandler : INotificationHandler<DomainEventNotification<TodoItemCreatedEvent>>
    {
        private readonly ILogger<TodoItemCompletedEventHandler> _logger;

        public TodoItemCreatedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<TodoItemCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("AluraFlix.API Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
