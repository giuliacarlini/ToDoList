using ToDoList.Features.v1.Database.EntityFramework.Data;
using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Database
{
    public class ListItemRepository : IListItemRepository
    {
        private readonly DataContext _context;

        public ListItemRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ListItem> GetListByID(int id)
        {
            return _context.ListItem.Where(x => x.List_id == id && x.ListItem_id <= 0);
        }

        public IEnumerable<ListItem> GetListItensByID(int id)
        {
            return _context.ListItem.Where(x => x.ListItem_id == id);
        }

        public int AddListItem(ListItem listItem)
        {
            _context.Add(listItem);
            _context.SaveChanges();

            return listItem.Id;
        }

        public ListItem GetListItemByID(int id)
        {
            return _context.ListItem.Where(x => x.Id == id).First();
        }

        public void UpdateListItem(ListItem _listItem)
        {
            _context.Update(_listItem);
            _context.SaveChanges();
        }

        public void DeleteListItem(int id)
        {
            ListItem _listItem = _context.ListItem.Where(x => x.Id == id).First();

            _context.Remove(_listItem);
            _context.SaveChanges();
        }
    }

}
