using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Request.List
{
    public class DeleteListRequest: ICommand
    {
        public int Id { get; set; }
    }
}
