using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Commands.Request.ListItem;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Commands.Response.ListItem;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Handlers;
using ToDoList.Infrastructure.Repositories;
using Xunit;

namespace ToDoList.Tests.Handlers
{
    public class ListItemHandlerTests
    {
        private readonly UserRepository _userRepository;
        private readonly ListRepository _listRepository;
        private readonly ListItemRepository _listItemRepository;

        public ListItemHandlerTests()
        {
            var context = new Configuration().ConfigureContext();

            _userRepository = new UserRepository(context);
            _listRepository = new ListRepository(context);
            _listItemRepository = new ListItemRepository(context);
        }

        private void CreateFakeDateForTests(out List list, out User user2)
        {
            var user = new User("Giulia Carlini", "giuliacarlini@gmail.com", "giuliacarlini", "12345678");
            _userRepository.AddUser(user);

            list = new List("Teste de Título de Lista", user.Id);
            _listRepository.AddList(list);

            user2 = new User("Giulia Carlini", "giuliacarlini@gmail.com", "giuliacarlini", "12345678");
            _userRepository.AddUser(user2);
        }


        [Fact]
        public void Tests_handler_listitem_create_invalid_user()
        {
            var user = new User("Giulia Carlini", "giuliacarlini@gmail.com", "giuliacarlini", "12345678");
            _userRepository.AddUser(user);

            var list = new List("Teste de Título de Lista", user.Id);
            _listRepository.AddList(list);

            var command = new CreateListItemRequest()
            {
                Description = "Tarefa descrição 1",
                Title = "Titulo descrição 1",
                IdList = list.Id,
                IdUser = user.Id
            };

            var handler = new ListItemHandler(_listItemRepository,_listRepository,_userRepository);

            var response = (CommandResponse)handler.Handle(command);

            Assert.False(response.Success);
            Assert.IsType<string>(response.Data);
            Assert.Contains("O usuário não pode ser igual ao vinculado a lista.", response.Data.ToString());
        }

        [Fact]
        public void Tests_handler_listitem_create_valid_user()
        {
            CreateFakeDateForTests(out var list, out var user2);

            var command = new CreateListItemRequest()
            {
                Description = "Tarefa descrição 1",
                Title = "Titulo descrição 1",
                IdList = list.Id,
                IdUser = user2.Id
            };

            var handler = new ListItemHandler(_listItemRepository, _listRepository, _userRepository);

            var response = (CommandResponse)handler.Handle(command);

            Assert.True(response.Success);
            Assert.IsType<ListItemResponse>(response.Data);
        }

        [Fact]
        public void Tests_handler_listitem_update()
        {
            CreateFakeDateForTests(out var list, out var user2);

            var listItem = new ListItem("Tarefa descrição 1", "Titulo descrição 1", list.Id, user2.Id);

            _listItemRepository.AddListItem(listItem);

            var description = "Tarefa descrição 2";
            var title = "Titulo descrição 2";

            var commandUpdate = new UpdateListItemRequest()
            {
                Id = list.Id,
                Description = description,
                Title = title,
            };

            var handler = new ListItemHandler(_listItemRepository, _listRepository, _userRepository);
            var response = (CommandResponse)handler.Handle(commandUpdate);

            var listItemResponse = (ListItemResponse)response.Data!;

            Assert.True(response.Success);
            Assert.IsType<ListItemResponse>(response.Data);
            Assert.Contains(description, listItemResponse.Description);
            Assert.Contains(title, listItemResponse.Title);
        }

        [Fact]
        public void Tests_handler_listitem_get()
        {
            CreateFakeDateForTests(out var list, out var user2);

            var listItem = new ListItem("Tarefa descrição 1", "Titulo descrição 1", list.Id, user2.Id);
            _listItemRepository.AddListItem(listItem);

            var command = new GetListItemByIdRequest(listItem.Id);

            var handler = new ListItemHandler(_listItemRepository, _listRepository, _userRepository);
            var response = (CommandResponse)handler.Handle(command);

            Assert.True(response.Success);
            Assert.IsType<ListItemResponse>(response.Data);
        }

        [Fact]
        public void Tests_handler_listitem_delete()
        {
            CreateFakeDateForTests(out var list, out var user2);

            var listItem = new ListItem("Tarefa descrição 1", "Titulo descrição 1", list.Id, user2.Id);
            _listItemRepository.AddListItem(listItem);

            var command = new DeleteListItemRequest()
            {
                Id = listItem.Id
            };

            var handler = new ListItemHandler(_listItemRepository, _listRepository, _userRepository);
            var response = (CommandResponse)handler.Handle(command);

            Assert.True(response.Success);
            Assert.IsType<string>(response.Data);
            Assert.Contains("excluído", response.Data.ToString());
        }
    }
}
