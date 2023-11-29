using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using ToDoList.Domain.Adapters.Handlers;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Commands.Request.List;
using ToDoList.Domain.Commands.Request.ListItem;
using ToDoList.Domain.Commands.Request.User;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Commands.Response.List;
using ToDoList.Domain.Commands.Response.User;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Handlers;
using ToDoList.Infrastructure.Repositories;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDoList.Tests.Handlers
{
    public class ListHandlerTests
    {
        private readonly UserRepository _userRepository;
        private readonly ListRepository _listRepository;

        public ListHandlerTests()
        {
            var context = new Configuration().ConfigureContext();
            _userRepository = new UserRepository(context);
            _listRepository = new ListRepository(context);
        }

        private CreateUserRequest CreateUserCommand()
        {
            return new CreateUserRequest()
            {
                Name = "Administrator",
                Email = "admadmadm@adm.com",
                Login = "administrador",
                Password = "1234567890"
            };
        }

        private CommandResponse CreateUser(UserRepository userRepository)
        {
            var handlerUser = new UserHandler(userRepository);
            return (CommandResponse)handlerUser.Handle(CreateUserCommand());
        }

        [Fact]
        public void Test_list_handler_create_success()
        {
            var commandResponse = CreateUser(_userRepository);

            var user = (UserResponse)commandResponse.Data!;

            var commandCreateListRequest = new CreateListRequest()
            {
                Title = "Teste de título",               
            };

            commandCreateListRequest.RefreshEmail(user.Email);

            var handlerList = new ListHandler(_listRepository, _userRepository);
            var handlerListResult = (CommandResponse)handlerList.Handle(commandCreateListRequest);

            var list = (ListResponse)handlerListResult.Data!;

            Assert.True(handlerListResult.Success);
            Assert.True(list is { Id: > 0 });
        }

        [Fact]
        public void Test_list_handler_create_list_invalid_user()
        {
            var commandResponse = CreateUser(_userRepository);

            var commandCreateListRequest = new CreateListRequest()
            {
                Title = "Teste de título"
            };

            commandCreateListRequest.RefreshEmail("emailerrado");


            var handlerList = new ListHandler(_listRepository, _userRepository);
            var handlerListResult = (CommandResponse)handlerList.Handle(commandCreateListRequest);

            Assert.False(handlerListResult.Success);
            Assert.NotNull(handlerListResult.Data);
            Assert.True(handlerListResult.Data.ToString() == "Login não cadastrado.");
        }


        [Fact]
        public void Test_list_handler_create_and_delete()
        {
            var commandResponse = CreateUser(_userRepository);

            var user = (UserResponse)commandResponse.Data!;

            var commandCreateListRequest = new CreateListRequest()
            {
                Title = "Teste de título",       
            };

            commandCreateListRequest.RefreshEmail(user.Email);

            var handlerList = new ListHandler(_listRepository, _userRepository);
            var handlerListCreateResult = (CommandResponse)handlerList.Handle(commandCreateListRequest);

            var list = (ListResponse)handlerListCreateResult.Data!;

            var commandDeleteListRequest = new DeleteListRequest()
            {
                Id = list.Id,
            };

            commandDeleteListRequest.RefreshEmail(user.Email);

            var handlerListDeleteResult = (CommandResponse)handlerList.Handle(commandDeleteListRequest);

            Assert.True(handlerListDeleteResult.Success);
            Assert.IsType<string>(handlerListDeleteResult.Data);
            Assert.Contains("Exclusão", handlerListDeleteResult.Data.ToString() ?? string.Empty);
            
        }

    }
}