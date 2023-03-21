using System.ComponentModel.DataAnnotations;
using ToDoList.Features.v1.Models;

namespace ToDoList.Features.v1.Database.DTOs
{
    public class ListItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int User_id { get; set; }
        public int List_id { get; set; }
        public int ListItem_id { get; set; }
        public List<ListItemDTO>? ListItems { get; set; }
    }
}
