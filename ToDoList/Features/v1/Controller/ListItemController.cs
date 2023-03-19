using Microsoft.AspNetCore.Authorization;
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

        //URI sugerida: /api/v{n}/lists/{ID}/items
        //Public: Não
        //Tipo: GET
        //Return Success: { "items" : { OBJECT1, OBJECT2 } }
        //Return Fail: { "message" : STRING }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                IEnumerable<ListItem> _listItems = _context.ListItem.Where(x => x.List_id == id && x.ListItem_id <= 0) ;

                _listItems = RetornaItens(_listItems);

                return Ok( new { items = _listItems } ); 
            }
            catch
            {
                return BadRequest(new { message = "" });
            }
        }

        private IEnumerable<ListItem> RetornaItens(IEnumerable<ListItem> listItems)
        {
            foreach (ListItem _listItem in listItems)
            {
                _listItem.ListItems = _context.ListItem.Where(x => x.ListItem_id == _listItem.Id);

                if (_listItem.ListItems != null)                    
                   RetornaItens(_listItem.ListItems);
            }

            return listItems;
        }


        //URI sugerida: / api / v{ n}/ lists /{ ID}/ items
        //Public: Não
        //Tipo: POST
        //Request: { "title": STRING, "description": STRING, “user_id”: INTEGER }
        //Return Success: { "item" : OBJECT }
        //Return Fail: { "message" : STRING }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] ListItem listItem)
        {
            try
            {
                List _list = _context.List.Where(x => x.ID == listItem.List_id).First();
                User _user = _context.Users.Where(x => x.Id == listItem.User_id).First();

                if (_user.Id == _list.User_id)
                    return BadRequest(new { message = "O usuário não pode ser igual ao vinculado a lista." });

                _context.Add(listItem);
                _context.SaveChanges();

                return Ok ( new { item = listItem } );
            }
            catch (Exception e)
            {
                return BadRequest( new { message = "Erro ao gravar item!" });
            }
        }

        //URI sugerida: /api/v{n}/lists/{ID}/items/{ID}
        //Public: Não
        //Tipo: PUT
        //Request: { "title": STRING, "description": STRING, “user_id”: INTEGER }
        //Return Success: { "item" : OBJECT }
        //Return Fail: { "message" : STRING }

        [HttpPut("{idItem}")]
        [MapToApiVersion("1.0")]
        [Authorize]
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
        [Authorize]
        public void Delete(int id)
        {
            ListItem _listItem = _context.ListItem.Where(x => x.Id == id).First();

            _context.Remove(_listItem);
            _context.SaveChanges();
        }
    }
}
