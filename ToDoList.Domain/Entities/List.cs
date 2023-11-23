using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities
{
    public class List
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set; }
    }
}
