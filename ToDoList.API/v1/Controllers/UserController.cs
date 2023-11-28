using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Commands.Request.User;
using ToDoList.Domain.Commands.Response;
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
            var result = (CommandResponse)_handler.Handle(command);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Post([FromBody] CreateUserRequest command)
        {
            var result = (CommandResponse)_handler.Handle(command);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Put([FromBody] UpdateUserRequest command)
        {
            var result = (CommandResponse)_handler.Handle(command);
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}