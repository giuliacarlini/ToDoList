using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Response
{
    public class CommandResponse : ICommandResult
    {
        public CommandResponse() { }

        public CommandResponse(bool success, object data)
        {
            Data = data;
            Success = success;
        }

        public CommandResponse(bool success)
        {
            Success = success;
        }

        public object? Data { get; set; }
        public bool Success { get; set; }
    }
}
