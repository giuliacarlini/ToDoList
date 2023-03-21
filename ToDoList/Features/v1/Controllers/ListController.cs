using Microsoft.AspNetCore.Mvc;
using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Services;

namespace ToDoList.Features.v1.Controllers
{
    [Route("api/v{version:apiVersion}/lists")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ListController : ControllerBase
    {
        private readonly IListService _servicesList;
        public ListController(IListService service)
        {
            _servicesList = service;
        }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult GetByID(int id)
        {
            try
            {
                ListDTO? listDTO = _servicesList.GetByID(id);

                return Ok(new
                {
                    list = listDTO
                });
            }
            catch
            {
                return NotFound(new { message = "Lista não encontrada" });
            }
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult Post([FromBody] ListDTO list)
        {
            try
            {
                list = _servicesList.Add(list);

                return Ok(new
                {
                    list = new { title = list.Title }
                });
            }
            catch
            {
                return BadRequest(new { message = "Lista não cadastrada." });
            }
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult Delete(int id)
        {
            try
            {
                _servicesList.Delete(id);

                return Ok();
            }
            catch
            {
                return BadRequest(new { message = "Lista não cadastrada." });
            }
        }
    }
}
