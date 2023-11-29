using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Commands.Request.ListItem;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Handlers;

namespace ToDoList.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/list/{id}/items")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ListItemController : ControllerBase
    {
        private readonly AuthenticatedUser _authenticateUser;
        public ListItemController(AuthenticatedUser authenticatedUser)
        {
            _authenticateUser = authenticatedUser;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult GetListItemById([FromServices] ListItemHandler handler, int id)
        {
            var result = (CommandResponse)handler.Handle(new GetListItemByIdRequest(id));
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Post([FromServices] ListItemHandler handler, [FromBody] CreateListItemRequest command)
        {
            var result = (CommandResponse)handler.Handle(command);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Update([FromServices] ListItemHandler handler, [FromBody] UpdateListItemRequest command)
        {
            var result = (CommandResponse)handler.Handle(command);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Delete([FromServices] ListItemHandler handler, [FromBody] DeleteListItemRequest command)
        {
            var result = (CommandResponse)handler.Handle(command);
            return result.Success ? Ok(result) : NotFound(result);
        }
    }
}
