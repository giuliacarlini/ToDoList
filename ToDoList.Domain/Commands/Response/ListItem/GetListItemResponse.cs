using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Commands.Response.ListItem
{
    public class GetListItemResponse
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int IdUser { get; set; }
        public int IdList { get; set; }
    }
}
