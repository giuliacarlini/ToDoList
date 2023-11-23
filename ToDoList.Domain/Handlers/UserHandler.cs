using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Commands.Request.User;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Commands.Response.User;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Handlers
{
    public class UserHandler : IHandler<CreateUserRequest>, IHandler<GetUserByIdRequest>, IHandler<UpdateUserRequest>
    {
        private readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Handle(CreateUserRequest command)
        {
            var user = new User()
            {
                Name = command.Name,
                Email = command.Email,
                Login = command.Login,
                Password = command.Password
            };

            _userRepository.AddUser(user);

            return new CommandResponse(true);
        }

        public ICommandResult Handle(UpdateUserRequest command)
        {
            var user = _userRepository.GetUserById(command.Id);

            if (user == null) return new CommandResponse(false, "");
            
            user.Name = command.Name ?? user.Name;
            user.Email = command.Email ?? user.Email;
            user.Login = command.Login ?? user.Login;

            _userRepository.UpdateUser(user);

            return new CommandResponse(true);
        }

        public ICommandResult Handle(GetUserByIdRequest command)
        {
            var user = _userRepository.GetUserById(command.Id);

            if (user == null) return new CommandResponse(false, "");

            var userResponse = new GetUserResponse()
            {
                Name = user.Name,
                Email = user.Email,
                Login = user.Login
            };

            return new CommandResponse(true, userResponse);
        }
    }
}
