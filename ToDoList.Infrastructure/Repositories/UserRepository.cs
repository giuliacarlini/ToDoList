using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Context;

namespace ToDoList.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public User GetUserById(int id)
        {
            return _context.Users.First(x => x.Id == id);
        }

        public int AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return user.Id;
        }
        public void UpdateUser(User userUpdate)
        {
            var user = _context.Users.First(x => x.Id == userUpdate.Id);
            user.Name = userUpdate.Name;
            user.Email = userUpdate.Email;
            user.Login = userUpdate.Login;
            user.Password = userUpdate.Password;

            _context.Update(userUpdate);
            _context.SaveChanges();
        }

        public User? GetUserByEmail(string? email)
        {
            return _context.Users.FirstOrDefault(x => string.Equals(x.Email, email, StringComparison.CurrentCultureIgnoreCase));
        }

        public User? GetUserByLogin(string login)
        {
            return _context.Users.FirstOrDefault(x => string.Equals(x.Login, login, StringComparison.CurrentCultureIgnoreCase));
        }

        public int Count()
        {
            return _context.Users.Count();
        }
    }
}
