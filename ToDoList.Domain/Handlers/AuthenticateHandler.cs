using Microsoft.Extensions.Options;
using ToDoList.API;
using ToDoList.Domain.Adapters.Handlers;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Authentication;
using ToDoList.Domain.Commands.Request.Authentication;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Handlers
{
    public class AuthenticateHandler : IHandler<AuthenticateRequest>
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public AuthenticateHandler(IUserRepository userRepository, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _appSettings = options.Value;
        }

        public ICommandResult Handle(AuthenticateRequest command)
        {
            if (_userRepository.Count() == 0)
            {
                var user = new User("Administrator", "adm@adm.com", "administrator", "12345678");
                _userRepository.AddUser(user);
            }

            var userExists = _userRepository.GetUserByEmailPassword(command.Email, command.Password);

            if (userExists == null)
                return new CommandResponse(false, "Login e/ou senha está(ão) inválido(s).");

            if (userExists.Password != command.Password)
                return new CommandResponse(false, "Login e/ou senha está(ão) inválido(s).");

            var token = JwtAuth.GenerateToken(userExists);

            return new CommandResponse(true, token);
        }

        public ICommandResult Handle(AuthenticateSsoRequest command)
        {
            var userExists = _userRepository.GetUserByEmail(command.Email);

            if (userExists == null)
                return new CommandResponse(false, "Usuário inválido.");

            return new CommandResponse(JwtAuth.ValidateToken(command.AppToken, out var errorMessage));
        }
    }
}
