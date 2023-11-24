using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Commands.Response.User
{
    public class UserResponse
    {
        public UserResponse(int id, string name, string email, string login)
        {
            Id = id;
            Name = name;
            Email = email;
            Login = login;
        }

        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Login { get; set; }
    }
}
