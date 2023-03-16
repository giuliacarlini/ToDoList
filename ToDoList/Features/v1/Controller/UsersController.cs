using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public User GetByID(int id)
        {
            return _context.Users.Where(x => x.Id == id).First();
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public User Post([FromBody] User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return user;
        }

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
        [MapToApiVersion("1.1")]
        public DateTime GetV1_1()
        {
            return DateTime.Now.AddYears(5);
        }


        [HttpGet]
        public User GetUsers(string email)
        {
            return _context.Users.Where(
                x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}