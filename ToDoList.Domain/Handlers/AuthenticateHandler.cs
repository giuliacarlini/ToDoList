using Microsoft.Extensions.Configuration;
using ToDoList.Domain.Adapters.Handlers;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Commands.Request.Authentication;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Handlers
{
    public class AuthenticateHandler : IHandler<AuthenticateRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticateHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public ICommandResult Handle(AuthenticateRequest command)
        {
            if (_userRepository.Count() == 0)
            {
                var user = new User("Administrator", "adm@adm.com", "adm", "123");
                _userRepository.AddUser(user);
            }

            var userExists = _userRepository.GetUserByLogin(command.Login);

            if (userExists == null)
                return new CommandResponse(false, "Login e/ou senha está(ão) inválido(s).");

            if (userExists.Password != command.Password)
                return new CommandResponse(false, "Login e/ou senha está(ão) inválido(s).");

            var secretJwtKey = _configuration["TokenConfigurations:SecretJwtKey"] ?? "";
            var seconds = _configuration["TokenConfigurations:Seconds"] ?? "";

            var token = JwtAuth.GenerateToken(userExists, secretJwtKey, int.Parse(seconds));

            return new CommandResponse(true, token);
        }

        public ICommandResult Handle(AuthenticateSsoRequest command)
        {
            var userExists = _userRepository.GetUserByEmail(command.Login);

            if (userExists == null)
                return new CommandResponse(false, "Usuário inválido.");

            var secretJwtKey = _configuration["TokenConfigurations:SecretJwtKey"];

            var valid = JwtAuth.ValidateToken(secretJwtKey, command.AppToken, out var errorMessage);

            return new CommandResponse(valid, "");
        }
    }
}
