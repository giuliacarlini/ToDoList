using System;
using System.Threading.Tasks;

using ToDoList.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Controllers.v1;
using ToDoList.Data;

namespace ToDoList.Features.v1.Authenticate
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController (DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/v{version:apiVersion}/authenticate")]
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