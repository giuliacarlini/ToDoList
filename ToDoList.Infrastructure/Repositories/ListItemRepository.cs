using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Context;

namespace ToDoList.Infrastructure.Repositories;

public class ListItemRepository : IListItemRepository
{
    private readonly DataContext _context;

    public ListItemRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<ListItem> GetListById(int id)
    {
        return _context.ListItems.Where(x => x.IdList == id && x.IdListItem <= 0);
    }

    public IEnumerable<ListItem> GetListItemsById(int id)
    {
        return _context.ListItems.Where(x => x.IdListItem == id);
    }

    public int AddListItem(ListItem listItem)
    {
        _context.Add(listItem);
        _context.SaveChanges();

        return listItem.Id;
    }

    public ListItem GetListItemById(int id)
    {
        return _context.ListItems.First(x => x.Id == id);
    }

    public void UpdateListItem(ListItem listItem)
    {
        _context.Update(listItem);
        _context.SaveChanges();
    }

    public void DeleteListItem(int id)
    {
        var listItem = _context.ListItems.First(x => x.Id == id);

        _context.Remove(listItem);
        _context.SaveChanges();
    }
}