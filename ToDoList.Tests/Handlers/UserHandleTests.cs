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
using ToDoList.Domain.Handlers;
using ToDoList.Infrastructure.Repositories;
using Xunit;

namespace ToDoList.Tests.Handlers
{
    public class UserHandleTests
    {
        private readonly UserRepository _userRepository;

        public UserHandleTests()
        {
            var context = new Configuration().ConfigureContext();
            _userRepository = new UserRepository(context);
        }

        [Fact]
        public void Test_handler_user_create()
        {
            var handler = new UserHandler(_userRepository);

            var command = new CreateUserRequest()
            {
                Email = "giuliacarlini@gmail.com",
                Login = "giuliacarlini",
                Name = "Giulia Carlini",
                Password = "123456879"
            };

            var result = (CommandResponse)handler.Handle(command);

            Assert.True(result.Success);
            Assert.IsType<UserResponse>(result.Data);
        }

        [Fact]
        public void Test_handler_user_get_by_id()
        {
            Test_handler_user_create();

            var handler = new UserHandler(_userRepository);

            var command = new GetUserByIdRequest(1, "adm@adm.com");

            var result = (CommandResponse)handler.Handle(command);
            Assert.True(result.Success);
            Assert.IsType<UserResponse>(result.Data);
        }

        [Fact]
        public void Test_handler_user_update()
        {
            Test_handler_user_create();

            var handler = new UserHandler(_userRepository);

            var command = new UpdateUserRequest()
            {
                Id = 1,
                Email = "gcarlini@teste.com"
            };

            var result = (CommandResponse)handler.Handle(command);

            Assert.True(result.Success);
        }
    }
}
