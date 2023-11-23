using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Request.List
{
    public class CreateListRequest : ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int IdUser { get; set; }
    }
}
