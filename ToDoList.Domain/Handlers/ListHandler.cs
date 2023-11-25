using ToDoList.Domain.Adapters.Handlers;
using ToDoList.Domain.Adapters.Repositories;
using ToDoList.Domain.Commands.Request;
using ToDoList.Domain.Commands.Request.List;
using ToDoList.Domain.Commands.Response;
using ToDoList.Domain.Commands.Response.List;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Handlers
{
    public class ListHandler: IHandler<CreateListRequest>, IHandler<GetListRequest>, IHandler<DeleteListRequest>
    {
        private readonly IListRepository _listRepository;
        private readonly IUserRepository _userRepository;

        public ListHandler(IListRepository listRepository, IUserRepository userRepository) 
        {
            _listRepository = listRepository;   
            _userRepository = userRepository;
        }

        public ICommandResult Handle(GetListRequest command)
        {
            var list = _listRepository.GetListById(command.Id);

            if (list == null)
                return new CommandResponse(false);

            var listResponse = new ListResponse()
            {
                Title = list.Title
            };
            
            return new CommandResponse(true, listResponse);
        }

        public ICommandResult Handle(CreateListRequest command)
        {
            var user = _userRepository.GetUserByLogin(command.LoginUser);

            if (user == null) return new CommandResponse(false, "Login não cadastrado.");

            var list = new List(command.Title, user.Id);

            _listRepository.AddList(list);

            var listResponse = new ListResponse()
            {
                Id = list.Id,
                Title = list.Title
            };

            return new CommandResponse(true, listResponse);
        }

        public ICommandResult Handle(DeleteListRequest command)
        {
            var list = _listRepository.GetListById(command.Id);

            _listRepository.DeleteList(list);

            return new CommandResponse(true, "Exclusão efetuada com sucesso.");
        }
    }
}
