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
    public class UserHandler: IHandler<CreateUserRequest>, 
                              IHandler<GetUserByIdRequest>, 
                              IHandler<UpdateUserRequest>
    {
        private readonly IUserRepository _userRepository;

        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Handle(CreateUserRequest command)
        {
            var user = new User(command.Name, command.Email, command.Login, command.Password);

            _userRepository.AddUser(user);

            var userResponse = new UserResponse(user.Id, user.Name, user.Email, user.Login);

            return new CommandResponse(true, userResponse);
        }

        public ICommandResult Handle(UpdateUserRequest command)
        {
            var user = _userRepository.GetUserById(command.Id);

            if (user == null) return new CommandResponse(false, "");
            
            user.Refresh(command.Name, command.Email, command.Login, command.Password);

            _userRepository.UpdateUser(user);

            return new CommandResponse(true);
        }

        public ICommandResult Handle(GetUserByIdRequest command)
        {
            var user = _userRepository.GetUserById(command.Id);

            if (user == null) return new CommandResponse(false, "");

            var userResponse = new UserResponse(user.Id, user.Name, user.Email, user.Login);

            return new CommandResponse(true, userResponse);
        }
    }
}
