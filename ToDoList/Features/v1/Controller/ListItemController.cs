using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Features.v1.Model;

namespace ToDoList.Features.v1.Controller
{
    [Route("api/v{version:apiVersion}/list/{id}/items")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ListItemController : ControllerBase
    {
        private readonly DataContext _context;

        public ListItemController(DataContext context)
        {
            _context = context;
        }

        //URI sugerida: /api/v{n}/lists/{ID}/ items
        //Public: Não
        //Tipo: GET
        //Return Success: { "items" : { OBJECT1, OBJECT2 } }
        //Return Fail: { "message" : STRING }

        [HttpGet("{idItem}")]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public ListItem GetByID(int idItem)
        {
            ListItem _listItem = _context.ListItem.Where(x => x.Id == idItem).First(); ;
            return _listItem;
        }


        //URI sugerida: / api / v{ n}/ lists /{ ID}/ items
        //Public: Não
        //Tipo: POST
        //Request: { "title": STRING, "description": STRING, “user_id”: INTEGER }
        //Return Success: { "item" : OBJECT }
        //Return Fail: { "message" : STRING }

        [HttpPost]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public ListItem Post([FromBody] ListItem listItem)
        {
            _context.Add(listItem);
            _context.SaveChanges();

            return listItem;
        }

        //URI sugerida: /api/v{n}/lists/{ID}/items/{ID}
        //Public: Não
        //Tipo: PUT
        //Request: { "title": STRING, "description": STRING, “user_id”: INTEGER }
        //Return Success: { "item" : OBJECT }
        //Return Fail: { "message" : STRING }

        [HttpPut("{idItem}")]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public ListItem Put(int idItem, [FromBody] ListItem listItem)
        {
            ListItem _listItem = _context.ListItem.Where(x => x.Id == idItem).First();

            _listItem.Title = listItem.Title;
            _listItem.Description = listItem.Description;

            _context.Update(_listItem);
            _context.SaveChanges();
            return _listItem;
        }


        //URI sugerida: / api / v{ n}/ lists /{ ID}/ items /{ ID}
        //Public: Não
        //Tipo: DELETE
        //Request: { "id": INTEGER }
        //Return Fail: { "message" : STRING }

        [HttpDelete("{idItem}")]
        [MapToApiVersion("1.0")]
        //[Authorize]
        public void Delete(int id)
        {
            ListItem _listItem = _context.ListItem.Where(x => x.Id == id).First();

            _context.Remove(_listItem);
            _context.SaveChanges();
        }
    }
}
