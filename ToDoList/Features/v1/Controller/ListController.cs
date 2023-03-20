using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Features.v1.Model;

namespace ToDoList.Features.v1.Controller
{
    [Route("api/v{version:apiVersion}/lists")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ListController : ControllerBase
    {
        private readonly DataContext _context;
        public ListController(DataContext context)
        {
            _context = context;
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
                List list = _context.List.Where(x => x.ID == id).First();

                return Ok(new
                {
                    list
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
        public async Task<IActionResult> Post([FromBody] List list)
        {
            try
            {
                _context.Add(list);
                _context.SaveChanges();

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
                List _list = _context.List.Where(x => x.ID == id).First();

                _context.Remove(_list);
                _context.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest(new { message = "Lista não cadastrada." });
            }
        }
    }
}
