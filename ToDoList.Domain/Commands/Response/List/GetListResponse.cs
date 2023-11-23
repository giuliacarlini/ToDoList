using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Response.List
{
    public class GetListResponse : ICommandResult
    {
        public string Title { get; set; } = string.Empty;
    }
}
