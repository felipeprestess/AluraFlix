﻿using AluraFlix.API.Application.Common.Exceptions;
using AluraFlix.API.Application.TodoItems.Commands.CreateTodoItem;
using AluraFlix.API.Application.TodoItems.Commands.UpdateTodoItem;
using AluraFlix.API.Application.TodoItems.Commands.UpdateTodoItemDetail;
using AluraFlix.API.Application.TodoLists.Commands.CreateTodoList;
using AluraFlix.API.Domain.Entities;
using AluraFlix.API.Domain.Enums;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using static Testing;

namespace AluraFlix.API.Application.IntegrationTests.TodoItems.Commands
{
    public class UpdateTodoItemDetailTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new UpdateTodoItemCommand
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateTodoItemCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            var command = new UpdateTodoItemDetailCommand
            {
                Id = itemId,
                ListId = listId,
                Note = "This is the note.",
                Priority = PriorityLevel.High
            };

            await SendAsync(command);

            var item = await FindAsync<TodoItem>(itemId);

            item.ListId.Should().Be(command.ListId);
            item.Note.Should().Be(command.Note);
            item.Priority.Should().Be(command.Priority);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 10000);
        }
    }
}
