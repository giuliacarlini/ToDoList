using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ToDoList.Features.v1.Database;
using ToDoList.Features.v1.Models;
using ToDoList.Features.v1.Database.DTOs;

namespace ToDoList.Features.v1.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public UserDTO? GetById(int id)
        {
            User? user;
            UserDTO? userDTO;

            try
            {
                user = _repository.GetUserById(id);
            }
            catch
            {
                user = null;
            }

            if (user != null)
            {
                userDTO = new UserDTO()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Login = user.Login,
                    Password = user.Password
                };

                return userDTO;
            }
            else 
            {
                return null;
            };            
        }

        public UserDTO Add(UserDTO userDTO)
        {
            User user = new User()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Login = userDTO.Login,
                Password = userDTO.Password
            };

            userDTO.Id = _repository.AddUser(user);

            return userDTO;
        }

        public void Update(int id, UserDTO userDTO)
        {
            User user = new User()
            {
                Id = id,
                Name = userDTO.Name,
                Email = userDTO.Email,
                Login = userDTO.Login,
                Password = userDTO.Password
            };

            _repository.UpdateUser(user);
        }

        public UserDTO GetByEmail(string email)
        {
            User user = _repository.GetUserByEmail(email);

            if (user != null)
            {
                UserDTO userDTO = new UserDTO()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Login = user.Login,
                    Password = user.Password
                };

                return userDTO;
            }
            else
            {
                return null;
            }
        }

        public UserDTO GetByLogin(string login)
        {
            User user = _repository.GetUserByLogin(login);

            if (user != null)
            {
                UserDTO userDTO = new UserDTO()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Login = user.Login,
                    Password = user.Password
                };

                return userDTO;
            }
            else
            {
                return null;
            }            
        }

        public int Count()
        {
            return _repository.Count();
        }
    }
}
