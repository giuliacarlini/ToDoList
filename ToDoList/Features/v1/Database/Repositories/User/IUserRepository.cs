using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Database
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        int AddUser(User user);
        void UpdateUser(User user);
        User GetUserByEmail(string email);
        User GetUserByLogin(string login);
        public int Count();
    }
}
