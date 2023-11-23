using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Adapters.Repositories
{
    public interface IUserRepository
    {
        User? GetUserById(int id);
        int AddUser(User user);
        void UpdateUser(User user);
        User? GetUserByEmail(string? email);
        User? GetUserByLogin(string login);
        public int Count();
    }
}
