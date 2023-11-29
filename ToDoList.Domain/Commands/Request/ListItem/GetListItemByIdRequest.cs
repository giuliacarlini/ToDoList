using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Request.ListItem
{
    public class GetListItemByIdRequest: ICommand
    {
        public GetListItemByIdRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
