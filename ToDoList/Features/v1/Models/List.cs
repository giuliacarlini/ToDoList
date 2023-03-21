using System.ComponentModel.DataAnnotations;

namespace ToDoList.Features.v1.Models
{
    public class List
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        public int User_id { get; set; }
    }
}
