using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Database
{
    public interface IListRepository
    {
        List GetListByID(int id);

        int AddList(List list);

        void DeleteList(int id);
    }
}
