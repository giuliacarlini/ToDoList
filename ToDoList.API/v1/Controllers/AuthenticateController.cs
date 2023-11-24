using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Commands.Request.Authentication;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Handlers;

namespace ToDoList.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/authenticate")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Auth([FromServices] AuthenticateHandler handler, [FromBody] AuthenticateRequest command)
        {
            try
            {
                var result = (CommandResponse)handler.Handle(command);

                return result.Success ? Ok(result) : NotFound(result);
            }
            catch
            {
                return BadRequest(new { error = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }


        [HttpPost("sso")]
        [AllowAnonymous]
        public ActionResult AuthSso([FromServices] AuthenticateHandler handler, [FromBody] AuthenticateSsoRequest command)
        {
            try
            {
                var result = (CommandResponse)handler.Handle(command);

                return result.Success ? Ok(result) : NotFound(result);
            }
            catch
            {
                return BadRequest(new { error = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }

        }
    }
}