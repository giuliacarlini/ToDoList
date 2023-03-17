using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;
using System;
using System.Xml.Linq;
using ToDoList.Data;
using ToDoList.Features.v1.Model;

namespace ToDoList.Features.v1.Controller
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiVersion("1.0")]

    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        //URI sugerida: /api/v{n}/users/{ID}
        //Public: NÃO
        //Tipo: GET
        //Return Success: { "user" : OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public User Get(int id)
        {
            return _context.Users.Where(x => x.Id == id).First();
        }

        //URI sugerida: /api/v{n}/users
        //Public: Não
        //Tipo: POST
        //Request: { "name": STRING, "email": STRING, "login": STRING; "password": STRING}
        //Return Success: { "user" : OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpPost]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public User Post([FromBody] User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return user;
        }

        //URI sugerida: /api/v{n}/users/{ID}
        //Public: Não
        //Tipo: PUT
        //Request: { "name": STRING, "email": STRING, "login": STRING; "password": STRING  }
        //Return Success: { "user" : OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public User Put(int id, [FromBody] User user)
        {
            User _user = _context.Users.Where(x => x.Id == id).First();

            _user.Name = user.Name;
            _user.Email = user.Email;
            _user.Login = user.Login;
            _user.Password = user.Password;
            _context.Update(_user);
            _context.SaveChanges();
            return _user;
        }

        [HttpGet]
        public User GetUsers(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower())
                .FirstOrDefault();
        }

        [HttpGet]
        public User GetUsersByLogin(string login)
        {
            return _context.Users.Where(x => x.Login.ToLower() == login.ToLower())
                .FirstOrDefault();
        }
    }
}