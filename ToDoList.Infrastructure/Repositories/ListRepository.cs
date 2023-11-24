using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Context;

namespace ToDoList.Infrastructure.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly DataContext _context;

        public ListRepository(DataContext context)
        {
            _context = context;
        }

        public List GetListById(int id)
        {
            return _context.Lists.FirstOrDefault(x => x.Id == id);
        }

        public List AddList(List list)
        {
            _context.Add(list);
            _context.SaveChanges();

            return list;
        }

        public void DeleteList(int id)
        {
            var list = _context.Lists.First(x => x.Id == id);

            if (list == null) 
                return;

            _context.Remove(list);
            _context.SaveChanges();
        }
    }
}
