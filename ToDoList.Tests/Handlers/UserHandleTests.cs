using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;
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
        [Fact]
        public void test_create_user()
        {
            var context = new Configuration().ConfigureContext();
            var userRepository = new UserRepository(context);
            var handler = new UserHandler(userRepository);

            var command = new CreateUserRequest()
            {
                Email = "giuliacarlini@gmail.com",
                Login = "gcarlini",
                Name = "Giulia Carlini",
                Password = "123"
            };

            var result = (CommandResponse)handler.Handle(command);

            Assert.True(result.Success);
            Assert.IsType<UserResponse>(result.Data);
        }

        [Fact]
        public void test_get_by_id_user()
        {
            test_create_user();

            var context = new Configuration().ConfigureContext();
            var userRepository = new UserRepository(context);
            var handler = new UserHandler(userRepository);

            var command = new GetUserByIdRequest()
            {
                Id = 1
            };

            var result = (CommandResponse)handler.Handle(command);
            Assert.True(result.Success);
            Assert.IsType<UserResponse>(result.Data);
        }

        [Fact]
        public void test_update_user()
        {
            test_create_user();

            var context = new Configuration().ConfigureContext();
            var userRepository = new UserRepository(context);
            var handler = new UserHandler(userRepository);

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
