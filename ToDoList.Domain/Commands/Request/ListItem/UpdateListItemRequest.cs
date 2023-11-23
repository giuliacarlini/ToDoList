using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Request.ListItem
{
    public class UpdateListItemRequest: ICommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int IdUser { get; set; }
        public int IdList { get; set; }
    }
}
