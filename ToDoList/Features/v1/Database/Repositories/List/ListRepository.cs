using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Database.EntityFramework.Data;
using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Database
{
    public class ListRepository : IListRepository
    {
        private readonly DataContext _context;

        public ListRepository(DataContext context)
        {
            _context = context;
        }

        public List GetListByID(int id)
        {
            return _context.List.Where(x => x.Id == id).First();
        }

        public int AddList(List list)
        {
            _context.Add(list);
            _context.SaveChanges();

            return list.Id;
        }

        public void DeleteList(int id)
        {
            List _list = _context.List.Where(x => x.Id == id).First();

            _context.Remove(_list);
            _context.SaveChanges();
        }
    }
}
