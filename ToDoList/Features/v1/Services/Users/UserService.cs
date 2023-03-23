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
                userDTO = new ()
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

        public UserDTO? GetByEmail(string email)
        {
            User user = _repository.GetUserByEmail(email);

            if (user != null)
            {
                UserDTO userDTO = new ()
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

        public UserDTO? GetByLogin(string login)
        {
            User user = _repository.GetUserByLogin(login);

            if (user != null)
            {
                UserDTO userDTO = new()
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

        public UserDTO Add(UserDTO userDTO)
        {

            string erroMensagem = ValidarCampos(userDTO);

            if (erroMensagem != null)
            {

            }

            User user = new ()
            {
                Name = userDTO.Name.Substring(1, 100),
                Email = userDTO.Email.Substring(1, 80),
                Login = userDTO.Login.Substring(1, 80),
                Password = userDTO.Password.Substring(1, 30)
            };

            userDTO.Id = _repository.AddUser(user);

            return userDTO;
        }

        public void Update(int id, UserDTO userDTO)
        {
            User user = new ()
            {
                Id = id,
                Name = userDTO.Name.Substring(1, 100),
                Email = userDTO.Email.Substring(1, 80),
                Login = userDTO.Login.Substring(1, 80),
                Password = userDTO.Password.Substring(1, 30)
            };

            _repository.UpdateUser(user);
        }

        public string ValidarCampos(UserDTO userDTO)
        {
            if (userDTO.Name.Length < 10) { 
                return "O nome do usuário não pode ser menor que 10 caracteres."; 
            }

            if (userDTO.Name.Length > 100)
            {
                return "O nome do usuário não pode ser maior que 100 caracteres.";
            }

            if (userDTO.Email.Length < 10)
            {
                return "O e-mail do usuário não pode ser menor que 10 caracteres.";
            }

            if (userDTO.Email.Length > 80)
            {
                return "O e-mail do usuário não pode ser maior que 80 caracteres.";
            }

            if (userDTO.Login.Length < 10)
            {
                return "O login do usuário não pode ser menor que 10 caracteres.";
            }

            if (userDTO.Login.Length > 80)
            {
                return "O login do usuário não pode ser maior que 80 caracteres.";
            }

            if (userDTO.Password.Length < 6)
            {
                return "A senha do usuário não pode ser menor que 6 caracteres.";
            }

            if (userDTO.Password.Length > 30)
            {
                return "A senha do usuário não pode ser maior que 80 caracteres.";
            }

            return "";
        }


        public int Count()
        {
            return _repository.Count();
        }
    }
}
