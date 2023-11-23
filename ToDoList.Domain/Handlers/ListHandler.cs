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

        public ListHandler(IListRepository listRepository) 
        {
            _listRepository = listRepository;   
        
        }

        public ICommandResult Handle(GetListRequest command)
        {
            var list = _listRepository.GetListById(command.Id);

            if (list == null)
                return new CommandResponse(false);

            var getListResponse = new GetListResponse()
            {
                Title = list.Title
            };
            
            return getListResponse;
        }

        public ICommandResult Handle(CreateListRequest command)
        {
            var list = new List()
            {
                Id = command.Id,
                Title = command.Title,
                UserId = command.IdUser
            };

            _listRepository.AddList(list);

            return new CommandResponse();
        }

        public ICommandResult Handle(DeleteListRequest command)
        {
            _listRepository.DeleteList(command.Id);

            return new CommandResponse();
        }
    }
}
