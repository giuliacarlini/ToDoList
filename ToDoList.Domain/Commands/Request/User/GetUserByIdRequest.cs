using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Request.User
{
    public class GetUserByIdRequest: ICommand
    {
        public GetUserByIdRequest(int id, string email)
        {
            Id = id;
            EmailUserRequest = email;
        }

        public int Id { get; set;}
        public string EmailUserRequest { get; private set;}
    }
}
