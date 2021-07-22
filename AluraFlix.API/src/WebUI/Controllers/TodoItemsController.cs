using AluraFlix.API.Application.Common.Models;
using AluraFlix.API.Application.TodoItems.Commands.CreateTodoItem;
using AluraFlix.API.Application.TodoItems.Commands.DeleteTodoItem;
using AluraFlix.API.Application.TodoItems.Commands.UpdateTodoItem;
using AluraFlix.API.Application.TodoItems.Commands.UpdateTodoItemDetail;
using AluraFlix.API.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using AluraFlix.API.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AluraFlix.API.WebUI.Controllers
{
    [Authorize]
    public class TodoItemsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<TodoItemDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoItemCommand { Id = id });

            return NoContent();
        }
    }
}
