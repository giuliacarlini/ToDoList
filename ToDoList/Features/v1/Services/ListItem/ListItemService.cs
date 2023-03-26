using Microsoft.EntityFrameworkCore;
using ToDoList.Features.v1.Database;
using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Services
{
    public class ListItemService : IListItemService
    {
        private readonly IListItemRepository _repository;

        public ListItemService(IListItemRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ListItemDTO> GetItensByID(int id)
        {
            List<ListItemDTO> listItensDTO = new List<ListItemDTO>();

            IEnumerable<ListItem> _listItems = _repository.GetListByID(id);

            ListItemDTO listItemDTO;

            foreach (ListItem item in _listItems)
            {
                listItemDTO = new ListItemDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    User_id = item.User_id,
                    List_id = item.List_id,
                    ListItem_id = item.ListItem_id
                };

                listItensDTO.Add(listItemDTO);
            }

            return RetornaItens(listItensDTO);
        }

        public List<ListItemDTO> RetornaItens(List<ListItemDTO> listItems)
        {
            foreach (ListItemDTO _listItem in listItems)
            {
                List<ListItemDTO> listItensDTO = new List<ListItemDTO>();

                IEnumerable<ListItem> _list = _repository.GetListItensByID(_listItem.Id);

                foreach (ListItem item in _list)
                {
                    var listItemDTO = new ListItemDTO
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        User_id = item.User_id,
                        List_id = item.List_id,
                        ListItem_id = item.ListItem_id
                    };

                    listItensDTO.Add(listItemDTO);
                }

                _listItem.ListItems = listItensDTO;

                if (_listItem.ListItems != null)
                    RetornaItens(_listItem.ListItems);
            }

            return listItems;
        }

        public ListItemDTO Add(ListItemDTO listItemDTO)
        {
            ListItem listItem = new ListItem()
            {
                Title = listItemDTO.Title,
                Description = listItemDTO.Description,
                User_id = listItemDTO.User_id,
                List_id = listItemDTO.List_id,
                ListItem_id = listItemDTO.ListItem_id
            };

            listItemDTO.Id = _repository.AddListItem(listItem);

            return listItemDTO;
        }

        public void Update(int id, ListItemDTO ListItemDTO)
        {
            ListItem listItem = new ListItem()
            {
                Id = id,
                Title = ListItemDTO.Title,
                Description = ListItemDTO.Description,
                User_id = ListItemDTO.User_id,
                List_id = ListItemDTO.List_id,
                ListItem_id = ListItemDTO.ListItem_id
            };

            _repository.UpdateListItem(listItem);
        }

        public void Delete(int id)
        {
            _repository.DeleteListItem(id);
        }
    }
}
