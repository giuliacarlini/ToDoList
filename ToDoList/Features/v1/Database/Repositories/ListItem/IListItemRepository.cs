using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Database
{
    public interface IListItemRepository
    {
        IEnumerable<ListItem> GetListByID(int id);
        IEnumerable<ListItem> GetListItensByID(int id);
        int AddListItem(ListItem listItem);
        ListItem GetListItemByID(int id);
        void UpdateListItem(ListItem _listItem);

        void DeleteListItem(int id);
    }
}
