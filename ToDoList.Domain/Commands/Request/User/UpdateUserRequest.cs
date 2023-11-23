using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Request.User
{
    public class UpdateUserRequest : ICommand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
    }
}
