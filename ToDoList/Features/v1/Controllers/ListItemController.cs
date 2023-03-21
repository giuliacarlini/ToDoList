using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Database.EntityFramework.Data;
using ToDoList.Features.v1.Models;
using ToDoList.Features.v1.Services;
using ToDoList.Features.v1.Services.Users;

namespace ToDoList.Features.v1.Controllers
{
    [Route("api/v{version:apiVersion}/list/{id}/items")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ListItemController : ControllerBase
    {
        private readonly IListItemService _serviceListItem;
        private readonly IListService _serviceList;
        private readonly IUserService _serviceUser;

        public ListItemController(IListItemService serviceListItem,
                                  IListService serviceList,
                                  IUserService serviceUser)
        {
            _serviceListItem = serviceListItem;
            _serviceList = serviceList;
            _serviceUser = serviceUser;
        }

        //URI sugerida: /api/v{n}/lists/{ID}/items
        //Public: Não
        //Tipo: GET
        //Return Success: { "items" : { OBJECT1, OBJECT2 } }
        //Return Fail: { "message" : STRING }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorize]
        public ActionResult GetByID(int id)
        {
            try
            {
                IEnumerable<ListItemDTO> _listItems = _serviceListItem.GetItensByID(id);

                return Ok(new { items = _listItems });
            }
            catch
            {
                return BadRequest(new { message = "" });
            }
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
        public ActionResult Post([FromBody] ListItemDTO listItem)
        {
            try
            {
                ListDTO _list = _serviceList.GetByID(listItem.List_id); //_context.List.Where(x => x.Id == listItem.List_id).First();
                UserDTO _user = _serviceUser.SearchById(listItem.User_id); //_context.Users.Where(x => x.Id == listItem.User_id).First();

                if (_user.Id == _list.User_id)
                    return BadRequest(new { message = "O usuário não pode ser igual ao vinculado a lista." });

                _serviceListItem.Add(listItem);

                return Ok(new { item = listItem });
            }
            catch
            {
                return BadRequest(new { message = "Erro ao gravar item!" });
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
        public ListItemDTO Update(int idItem, [FromBody] ListItemDTO listItem)
        {
            _serviceListItem.Update(idItem, listItem);
            listItem.Id = idItem;

            return listItem;
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
            _serviceListItem.Delete(id);
        }
    }
}
