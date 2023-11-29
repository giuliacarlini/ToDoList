using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Commands.Request;
using ToDoList.Domain.Commands.Request.List;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Handlers;

namespace ToDoList.API.v1.Controllers;

[Route("api/v{version:apiVersion}/lists")]
[ApiController]
[ApiVersion("1.0")]
public class ListController : ControllerBase
{
    private readonly AuthenticatedUser _authenticateUser;

    public ListController(AuthenticatedUser authenticatedUser)
    { 
        _authenticateUser = authenticatedUser;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize]
    public ActionResult GetById([FromServices] ListHandler handler, int id)
    {
        var result = (CommandResponse)handler.Handle(new GetListRequest(id, _authenticateUser.Email));
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    [Authorize]
    public ActionResult Post([FromServices] ListHandler handler, [FromBody] CreateListRequest command)
    {
        command.RefreshEmail(_authenticateUser.Email);

        var result = (CommandResponse)handler.Handle(command);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpDelete]
    [MapToApiVersion("1.0")]
    [Authorize]
    public ActionResult Delete([FromServices] ListHandler handler, [FromBody] DeleteListRequest command)
    {
        command.RefreshEmail(_authenticateUser.Email);

        var result = (CommandResponse)handler.Handle(command);
        return result.Success ? Ok(result) : NotFound(result);
    }
}