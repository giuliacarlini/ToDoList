using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Commands.Request.List;
using ToDoList.Domain.Commands.Request.ListItem;
using ToDoList.Domain.Commands.Request.User;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Handlers;
using ToDoList.Infrastructure.Context;
using ToDoList.Infrastructure.Repositories;
using Xunit;

namespace ToDoList.Tests.Handlers
{
    public class ListHandlerTests
    {
        [Fact]
        public void Tests_create_list()
        {
            var context = new Configuration().ConfigureContext();

            var userRepository = CreateUser(context, out var handlerUserResult);

            Assert.True(handlerUserResult.Success);

            var commandCreateListRequest = new CreateListRequest()
            {
                Title = "Teste de título",
                LoginUser = "adm"
            };

            ExecuteListHandlerWithDependecies(context, userRepository, commandCreateListRequest, out var handlerListResult);

            var list = (List)handlerListResult.Data!;

            Assert.True(handlerListResult.Success);
            Assert.True(list is { Id: > 0 });
        }

        [Fact]
        public void Tests_create_list_invalid_user()
        {
            var context = new Configuration().ConfigureContext();

            var userRepository = CreateUser(context, out var handlerUserResult);

            Assert.True(handlerUserResult.Success);

            var commandCreateListRequest = new CreateListRequest()
            {
                Title = "Teste de título",
                LoginUser = "admWrong"
            };

            ExecuteListHandlerWithDependecies(context, userRepository, commandCreateListRequest, out var handlerListResult);

            Assert.False(handlerListResult.Success);
            Assert.NotNull(handlerListResult.Data);
            Assert.True(handlerListResult.Data.ToString() == "Login não cadastrado.");
        }

        private static void ExecuteListHandlerWithDependecies(DataContext context, UserRepository userRepository,
            CreateListRequest commandCreateListRequest, out CommandResponse result)
        {
            var listRepository = new ListRepository(context);
            var handlerList = new ListHandler(listRepository, userRepository);
            result = (CommandResponse)handlerList.Handle(commandCreateListRequest);
        }

        private static UserRepository CreateUser(DataContext context, out CommandResponse handlerUserResult)
        {
            var commandCreateUserRequest = new CreateUserRequest()
            {
                Name = "Administrator",
                Email = "adm@adm.com",
                Login = "adm",
                Password = "123"
            };

            var userRepository = new UserRepository(context);
            var handlerUser = new UserHandler(userRepository);
            handlerUserResult = (CommandResponse)handlerUser.Handle(commandCreateUserRequest);

            return userRepository;
        }
    }
}