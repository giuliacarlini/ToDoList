using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Commands.Request.ListItem;
using ToDoList.Domain.Handlers;

namespace ToDoList.API.v1.Controllers
{
    [Route("api/v{version:apiVersion}/list/{id}/items")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ListItemController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult GetListItemById([FromServices] ListItemHandler handler, 
            [FromBody] GetListItemByIdRequest command)
        {
            try
            {
                var result = handler.Handle(command);

                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "" });
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Post([FromServices] ListItemHandler handler,
            [FromBody] CreateListItemRequest command)
        {
            try
            {
                var result = handler.Handle(command);

                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Erro ao gravar item!" });
            }
        }

        [HttpPut]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Update([FromServices] ListItemHandler handler,
            [FromBody] UpdateListItemRequest command)
        {
            try
            {
                var result = handler.Handle(command);

                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Erro ao atualizar item!" });
            }
        }

        [HttpDelete]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult Delete([FromServices] ListItemHandler handler,
            [FromBody] DeleteListItemRequest command)
        {
            try
            {
                var result = handler.Handle(command);

                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Erro ao excluir!" });
            }
        }
    }
}
