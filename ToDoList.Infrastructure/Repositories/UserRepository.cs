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
        public User? GetUserById(int id)
        {
            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();

            return user;
        }

        public User AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return user;
        }
        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public User? GetUserByEmail(string? email)
        {
            return _context.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User? GetUserByLogin(string login) => _context.Users.Where(x => x.Login == login).FirstOrDefault();

        public int Count() => _context.Users.Count();

        public User? GetUserByEmailPassword(string email, string password) => _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
    }
}
