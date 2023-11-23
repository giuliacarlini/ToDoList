using Microsoft.Extensions.Configuration;
using ToDoList.Domain.Adapters.Handlers;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Handlers
{
    public class AuthenticateHandler : IHandler<Authenticate>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticateHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public ICommandResult Handle(Authenticate command)
        {
            if (command.Email == null || command.Password == null)
                return new CommandResponse(false);
            
            if (_userRepository.Count() == 0)
            {
                var user = new User()
                {
                    Name = "Administrator",
                    Email = "adm@adm.com",
                    Login = "adm",
                    Password = "123"
                };

                _userRepository.AddUser(user);
            }

            var userExists = _userRepository.GetUserByEmail(command.Email);

            if (userExists == null)
                return new CommandResponse(false, "Email e/ou senha está(ão) inválido(s).");

            if (userExists.Password != command.Password)
                return new CommandResponse(false, "Email e/ou senha está(ão) inválido(s).");

            var secretJwtKey = _configuration["TokenConfigurations:SecretJwtKey"] ?? "";
            var seconds = _configuration["TokenConfigurations:Seconds"] ?? "";

            var token = JwtAuth.GenerateToken(userExists, secretJwtKey, int.Parse(seconds));

            return new CommandResponse(true, token);
        }

        public ICommandResult Handle(AuthenticateSSO command)
        {
            if (command.App_token == null || command.Login == null) 
                return new CommandResponse(false, "");

            var userExists = _userRepository.GetUserByEmail(command.Login);

            if (userExists == null)
                return new CommandResponse(false, "");

            var secretJwtKey = _configuration["TokenConfigurations:SecretJwtKey"];

            var valid = JwtAuth.ValidateToken(secretJwtKey, command.App_token, out var mensagemErro);

            return new CommandResponse(valid, "");
        }
    }
}
