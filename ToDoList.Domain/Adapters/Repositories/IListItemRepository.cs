using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Adapters.Repositories
{
    public interface IListItemRepository
    {
        IEnumerable<ListItem> GetListById(int id);
        IEnumerable<ListItem> GetListItemsById(int id);
        int AddListItem(ListItem listItem);
        ListItem? GetListItemById(int id);
        void UpdateListItem(ListItem listItem);
        void DeleteListItem(int id);
    }
}
