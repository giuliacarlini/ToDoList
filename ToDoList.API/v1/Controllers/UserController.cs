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

        private readonly AuthenticatedUser _authenticateUser;

        public UserController(UserHandler handler, AuthenticatedUser authenticatedUser)
        {
            _handler = handler;
            _authenticateUser = authenticatedUser;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Get(int id)
        {
            var result = (CommandResponse)_handler.Handle(new GetUserByIdRequest(id, _authenticateUser.Email));
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [AllowAnonymous]
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
            command.RefreshEmailUser(_authenticateUser.Email);

            var result = (CommandResponse)_handler.Handle(command);
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}