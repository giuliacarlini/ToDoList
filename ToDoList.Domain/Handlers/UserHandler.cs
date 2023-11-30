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
            if (_userRepository.GetUserByEmail(command.Email) != null)
                return new CommandResponse(false, "E-mail já cadastrado.");

            var user = new User(command.Name, command.Email, command.Login, command.Password);

            if (user.IsValid)
                _userRepository.AddUser(user);
            else
                return new CommandResponse(false, user.Notifications);

            var userResponse = new UserResponse(user.Id, user.Name, user.Email, user.Login);

            return new CommandResponse(true, userResponse);
        }

        public ICommandResult Handle(UpdateUserRequest command)
        {
            var user = _userRepository.GetUserById(command.Id);

            if (user == null)
                return new CommandResponse(false, "Usuário não encontrado.");

            //if (user.Email != command.EmailUserRequest)
            //    return new CommandResponse(false, "O usuário solicitante é diferente do usuário solicitado para a alteração.");
            
            user.Refresh(command.Name, command.Email, command.Login, command.Password);

            if (user.IsValid == false)
                return new CommandResponse(false, user.Notifications);

            _userRepository.UpdateUser(user);

            return new CommandResponse(true);
        }

        public ICommandResult Handle(GetUserByIdRequest command)
        {
            if (command.Id <= 0)
                return new CommandResponse(false, "Requisição inválida.");
           
            var user = _userRepository.GetUserById(command.Id);

            if (user == null)
                return new CommandResponse();

            var userResponse = new UserResponse(user.Id, user.Name, user.Email, user.Login);
                return new CommandResponse(true, userResponse);                
        }
    }
}
