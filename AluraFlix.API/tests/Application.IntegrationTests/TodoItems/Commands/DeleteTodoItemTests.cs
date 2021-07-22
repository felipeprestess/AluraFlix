using AluraFlix.API.Application.Common.Exceptions;
using AluraFlix.API.Application.TodoItems.Commands.CreateTodoItem;
using AluraFlix.API.Application.TodoItems.Commands.DeleteTodoItem;
using AluraFlix.API.Application.TodoLists.Commands.CreateTodoList;
using AluraFlix.API.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using static Testing;

namespace AluraFlix.API.Application.IntegrationTests.TodoItems.Commands
{
    public class DeleteTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new DeleteTodoItemCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            await SendAsync(new DeleteTodoItemCommand
            {
                Id = itemId
            });

            var list = await FindAsync<TodoItem>(listId);

            list.Should().BeNull();
        }
    }
}
