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
        try
        {
            var result = (CommandResponse)handler.Handle(command);

            return result.Success ? Ok(result) : NotFound(result);
        }
        catch
        {
            return NotFound(new { message = "Lista não encontrada" });
        }
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    public ActionResult Post([FromServices] ListHandler handler, [FromBody] CreateListRequest command)
    {
        try
        {
            var result = (CommandResponse)handler.Handle(command);

            return result.Success ? Ok(result) : NotFound(result);
        }
        catch
        {
            return BadRequest(new { message = "Lista não cadastrada." });
        }
    }

    [HttpDelete]
    [MapToApiVersion("1.0")]
    public ActionResult Delete([FromServices] ListHandler handler, [FromBody] DeleteListRequest command)
    {
        try
        {
            var result = (CommandResponse)handler.Handle(command);

            return result.Success ? Ok(result) : NotFound(result);
        }
        catch
        {
            return BadRequest(new { message = "Lista não cadastrada." });
        }
    }
}