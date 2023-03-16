using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Controllers.v1
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] 
        [MapToApiVersion("1.0")]
        [Authorize]
        public DateTime GetV1_0()
        {
            return DateTime.Now;
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        public DateTime GetV1_1()
        {
            return DateTime.Now.AddYears(5);
        }

        [HttpGet]
        [MapToApiVersion("1.2")]
        public IEnumerable<User> GetV1_2()
        {
            return _context.Users;
        }

        [HttpGet]
        public User GetUsers(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}