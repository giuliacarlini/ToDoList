using System.ComponentModel.DataAnnotations;

namespace ToDoList.Features.v1.Models
{
    public class ListItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; set; }

        [Required]
        public int User_id { get; set; }

        [Required]
        public int List_id { get; set; }

        public int ListItem_id { get; set; }

        public IEnumerable<ListItem>? ListItems { get; set; }
    }
}
