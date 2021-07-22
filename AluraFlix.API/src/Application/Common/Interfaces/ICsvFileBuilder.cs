﻿using AluraFlix.API.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace AluraFlix.API.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
