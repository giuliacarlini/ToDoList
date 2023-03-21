using Microsoft.AspNetCore.Mvc;
using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Database.EntityFramework.Data;
using ToDoList.Features.v1.Models;
using ToDoList.Features.v1.Services;

namespace ToDoList.Features.v1.Controllers
{
    [Route("api/v{version:apiVersion}/lists")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ListController : ControllerBase
    {
        private readonly IListService _services;
        public ListController(IListService service)
        {
            _services = service;
        }

        //URI sugerida: /api/v{n}/lists/{ID}
        //Public: Sim
        //Tipo: GET
        //Return Success: { "list" : OBJECT,  “user_id”: INTEGER }
        //Return Fail: { "message" : STRING }

        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                ListDTO listDTO = _services.GetByID(id);

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

        //URI sugerida: /api/v{n}/lists
        //Public: Sim
        //Tipo: POST
        //Request: { "title": STRING }
        //Return Success: { "list" : { "title" : STRING } }
        //Return Fail: { "message" : STRING }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Post([FromBody] ListDTO list)
        {
            try
            {
                list = _services.Add(list);

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

        //URI sugerida: /api/v{n}/lists/{ID}
        //Public: Não
        //Tipo: DELETE
        //Request: { "id": INTEGER }
        //Return Fail: { "message" : STRING }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _services.Delete(id);

                return Ok();
            }
            catch
            {
                return BadRequest(new { message = "Lista não cadastrada." });
            }
        }
    }
}
