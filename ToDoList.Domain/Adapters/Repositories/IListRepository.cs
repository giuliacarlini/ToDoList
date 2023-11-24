using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Adapters.Repositories
{
    public interface IListRepository
    {
        List? GetListById(int id);
        List AddList(List list);
        void DeleteList(int id);
    }
}
