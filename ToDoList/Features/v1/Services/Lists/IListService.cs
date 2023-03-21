using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Services
{
    public interface IListService
    {
        ListDTO? GetByID(int id);
        ListDTO Add(ListDTO listDTO);
        void Delete(int id);
    }
}
