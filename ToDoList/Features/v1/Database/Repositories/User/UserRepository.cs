using Microsoft.EntityFrameworkCore;
using ToDoList.Features.v1.Database.EntityFramework.Data;
using ToDoList.Features.v1.Models;
using static ToDoList.Features.v1.Controllers.AuthenticateController;

namespace ToDoList.Features.v1.Database
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public User SearchUserById(int id)
        {
            return _context.Users.Where(x => x.Id == id).First();
        }

        public int AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();

            return user.Id;
        }
        public void UpdateUser(User user)
        {
            User _user = _context.Users.Where(x => x.Id == user.Id).First();
            _user.Name = user.Name;
            _user.Email = user.Email;
            _user.Login = user.Login;
            _user.Password = user.Password;

            _context.Update(_user);
            _context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public User GetUserByLogin(string login)
        {
            return _context.Users.Where(x => x.Login.ToLower() == login.ToLower()).FirstOrDefault();
        }
    }
}
