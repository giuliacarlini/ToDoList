using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
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
        //[Authorize]
        public List GetByID(int id)
        {
            List _list = _context.List.Where(x => x.ID == id).First(); ;
            return _list;
        }

        //URI sugerida: /api/v{n}/lists
        //Public: Sim
        //Tipo: POST
        //Request: { "title": STRING }
        //Return Success: { "list" : { "title" : STRING } }
        //Return Fail: { "message" : STRING }

        [HttpPost]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public List Post([FromBody] List list)
        {
            _context.Add(list);
            _context.SaveChanges();

            return list;
        }

        //URI sugerida: /api/v{n}/lists/{ID}
        //Public: Não
        //Tipo: DELETE
        //Request: { "id": INTEGER }
        //Return Fail: { "message" : STRING }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public void Delete(int id)
        {
            List _list = _context.List.Where(x => x.ID == id).First(); 

            _context.Remove(_list);
            _context.SaveChanges();
        }
    }
}
