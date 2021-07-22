using AluraFlix.API.Application.Common.Exceptions;
using AluraFlix.API.Application.TodoLists.Commands.CreateTodoList;
using AluraFlix.API.Application.TodoLists.Commands.DeleteTodoList;
using AluraFlix.API.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using static Testing;

namespace AluraFlix.API.Application.IntegrationTests.TodoLists.Commands
{
    public class DeleteTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteTodoListCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            await SendAsync(new DeleteTodoListCommand
            {
                Id = listId
            });

            var list = await FindAsync<TodoList>(listId);

            list.Should().BeNull();
        }
    }
}
