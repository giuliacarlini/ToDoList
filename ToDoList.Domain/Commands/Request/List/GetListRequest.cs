using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Request.List
{
    public class GetListRequest : ICommand
    {
        public GetListRequest(int id, string email)
        {
            Id = id;
            Email = email;
        }

        public int Id { get; set; }
        public string Email { get; }
    }
}
