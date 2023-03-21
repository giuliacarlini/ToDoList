using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Features.v1.Database;
using ToDoList.Features.v1.Database.DTOs;
using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Services.Lists
{
    public class ListService : IListService
    {
        private readonly IListRepository _repository;

        public ListService(IListRepository repository)
        {
            _repository = repository;
        }

        public ListDTO GetByID(int id)
        {
            List list = _repository.GetListByID(id);

            ListDTO listDTO = null;

            if (list != null)
            {
                listDTO = new ListDTO()
                {
                    Id = list.Id,
                    Title = list.Title,
                    User_id = list.User_id
                };
            }

            return listDTO;           
        }

        public ListDTO Add(ListDTO listDTO)
        {
            List list = new List()
            {
                Id = listDTO.Id,
                Title = listDTO.Title,
                User_id = listDTO.User_id
            };

            listDTO.Id = _repository.AddList(list);

            return listDTO;
        }

        public void Delete(int id)
        {
            _repository.DeleteList(id);
        }
    }
}
