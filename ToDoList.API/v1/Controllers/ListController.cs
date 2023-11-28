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
    [HttpGet]
    [MapToApiVersion("1.0")]
    public ActionResult GetById([FromServices] ListHandler handler, GetListRequest command)
    {
        var result = (CommandResponse)handler.Handle(command);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    public ActionResult Post([FromServices] ListHandler handler, [FromBody] CreateListRequest command)
    {
        var result = (CommandResponse)handler.Handle(command);
        return result.Success ? Ok(result) : NotFound(result);
    }

    [HttpDelete]
    [MapToApiVersion("1.0")]
    public ActionResult Delete([FromServices] ListHandler handler, [FromBody] DeleteListRequest command)
    {
        var result = (CommandResponse)handler.Handle(command);
        return result.Success ? Ok(result) : NotFound(result);
    }
}