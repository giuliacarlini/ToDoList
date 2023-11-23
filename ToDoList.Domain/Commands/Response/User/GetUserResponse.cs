using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Commands.Response.User
{
    public class GetUserResponse
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
    }
}
