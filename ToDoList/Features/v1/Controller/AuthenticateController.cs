using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Features.v1.Model;

namespace ToDoList.Features.v1.Controller
{
    [Route("api/v{version:apiVersion}/authenticate")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticateController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthenticateController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous] 
        public async Task<IActionResult> Auth([FromBody] User user)
        {
            try
            {
                var userExists = new UsersController(_context).GetUsers(user.Email);

                if (userExists == null)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });


                if (userExists.Password != user.Password)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });


                var token = JwtAuth.GenerateToken(userExists);

                return Ok(new
                {
                    Token = token,
                    Usuario = userExists
                });

            }
            catch (Exception e)
            {
                return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }
    }
}