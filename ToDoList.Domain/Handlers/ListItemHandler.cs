using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Adapters.Handlers;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Commands.Request.ListItem;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Commands.Response.ListItem;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Handlers
{
    public class ListItemHandler: 
        IHandler<GetListItemByIdRequest>,
        IHandler<CreateListItemRequest>,
        IHandler<UpdateListItemRequest>,
        IHandler<DeleteListItemRequest>

    {
        private readonly IListItemRepository _listItemRepository;
        private readonly IListRepository _listRepository;
        private readonly IUserRepository _userRepository;

        public ListItemHandler(IListItemRepository listItemRepository, IListRepository listRepository, IUserRepository userRepository)
        {
            _listItemRepository = listItemRepository;
            _listRepository = listRepository;
            _userRepository = userRepository;
        }

        public ICommandResult Handle(GetListItemByIdRequest command)
        {
            var listItems = _listItemRepository.GetListById(command.Id);

            var listResponse = listItems.Select(item => new GetListItemResponse
                {
                    Title = item.Title ?? "",
                    Description = item.Description ?? "",
                    IdUser = item.IdUser,
                    IdList = item.IdList
                })
                .ToList();

            return new CommandResponse(true, listResponse);
        }

        public ICommandResult Handle(CreateListItemRequest command)
        {
            var list = _listRepository.GetListById(command.IdList);

            if (list == null) return new CommandResponse(false, "A lista está inválida");

            var user = _userRepository.GetUserById(command.IdUser);

            if (user == null) return new CommandResponse(false, "O usuário está inválido");
            
            if (user.Id == list.UserId)
                return new CommandResponse(false, "O usuário não pode ser igual ao vinculado a lista.");

            var listItem = new ListItem(command.Title, command.Description, command.IdUser, command.IdList);

            _listItemRepository.AddListItem(listItem);

            return new CommandResponse(true, "Item da lista cadastrada com sucesso!" );
        }

        public ICommandResult Handle(UpdateListItemRequest command)
        {
            var listItem = _listItemRepository.GetListItemById(command.Id);

            if (listItem == null) return new CommandResponse(false, "A lista está inválida");

            listItem.Refresh(command.Title,command.Description);

            _listItemRepository.UpdateListItem(listItem);

            return new CommandResponse(true, "Item da lista alterado com sucesso");
        }

        public ICommandResult Handle(DeleteListItemRequest command)
        {
            _listItemRepository.DeleteListItem(command.Id);

            return new CommandResponse(true, "Item da lista excluído com sucesso.");
        }
    }
}
