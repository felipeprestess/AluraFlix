using AluraFlix.API.Domain.Common;
using AluraFlix.API.Domain.Entities;

namespace AluraFlix.API.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
