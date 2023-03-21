using ToDoList.Features.v1.Database.DTOs;

namespace ToDoList.Features.v1.Services
{
    public interface IUserService
    {
        UserDTO? GetById(int id);
        UserDTO Add(UserDTO userDTO);
        void Update(int id, UserDTO userDTO);
        UserDTO GetByEmail(string email);
        UserDTO GetByLogin(string login);
        int Count();
    }
}
