using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Commands.Request.User;
using ToDoList.Domain.Handlers;

namespace ToDoList.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [ApiVersion("1.0")]

    public class UserController : ControllerBase
    {
        private readonly UserHandler _handler;

        public UserController(UserHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Get([FromBody] GetUserByIdRequest command)
        {
            try
            {
                var result = _handler.Handle(command);
                return Ok(result);
            }
            catch
            {
                return NotFound(new { error = "Erro ao encontrar o usuário." });
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Post([FromBody] CreateUserRequest command)
        {
            try
            {
                var result = _handler.Handle(command);
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { error = "Erro ao cadastrar o usuário." });
            }

        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Put([FromBody] UpdateUserRequest command)
        {
            try
            {
                var result = _handler.Handle(command);
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { error = "Erro ao alterar o usuário." });
            }
        }

    }
}