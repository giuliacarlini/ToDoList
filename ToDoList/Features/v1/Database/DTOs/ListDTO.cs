using System.ComponentModel.DataAnnotations;

namespace ToDoList.Features.v1.Database.DTOs
{
    public class ListDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int User_id { get; set; }
    }
}
