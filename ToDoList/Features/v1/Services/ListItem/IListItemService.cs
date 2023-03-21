using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Services
{
    public interface IListItemService
    {
        IEnumerable<ListItemDTO> GetItensByID(int id);
        List<ListItemDTO> RetornaItens(List<ListItemDTO> listItems);
        ListItemDTO Add(ListItemDTO listItemDTO);
        void Update(int id, ListItemDTO ListItemDTO);
        void Delete(int id);
    }
}
