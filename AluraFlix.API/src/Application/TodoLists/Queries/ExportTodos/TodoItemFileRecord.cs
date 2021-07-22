using AluraFlix.API.Application.Common.Mappings;
using AluraFlix.API.Domain.Entities;

namespace AluraFlix.API.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
