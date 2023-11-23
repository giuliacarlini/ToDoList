using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities
{
    public class ListItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Description { get; set; }

        [Required]
        public int IdUser { get; set; }

        [Required]
        public int IdList { get; set; }

        public int IdListItem { get; set; }

        public IEnumerable<ListItem>? ListItems { get; set; }
    }
}
