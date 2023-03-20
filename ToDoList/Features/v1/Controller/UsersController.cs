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

        //URI sugerida: /api/v{n}/users/{ID}
        //Public: NÃO
        //Tipo: GET
        //Return Success: { "user" : OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                User user = _context.Users.Where(x => x.Id == id).First();

                return Ok(new
                {
                    user
                });
            }
            catch
            {
                return NotFound(new { error = "Erro ao encontrar o usuário." });
            }
        }

        //URI sugerida: /api/v{n}/users
        //Public: Não
        //Tipo: POST
        //Request: { "name": STRING, "email": STRING, "login": STRING; "password": STRING}
        //Return Success: { "user" : OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();

                return Ok(new
                {
                    user
                });
            }
            catch
            {
                return BadRequest(new { error = "Erro ao cadastrar o usuário." });
            }

        }

        //URI sugerida: /api/v{n}/users/{ID}
        //Public: Não
        //Tipo: PUT
        //Request: { "name": STRING, "email": STRING, "login": STRING; "password": STRING  }
        //Return Success: { "user" : OBJECT }
        //Return Fail: { "error" : STRING }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            try
            {
                User _user = _context.Users.Where(x => x.Id == id).First();

                _user.Name = user.Name;
                _user.Email = user.Email;
                _user.Login = user.Login;
                _user.Password = user.Password;
                _context.Update(_user);
                _context.SaveChanges();

                return Ok(new
                {
                    user
                });
            }
            catch
            {
                return BadRequest(new { error = "Erro ao alterar o usuário." });
            }
        }
    }
}