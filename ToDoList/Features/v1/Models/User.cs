using System.ComponentModel.DataAnnotations;

namespace ToDoList.Features.v1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MaxLength(80)]
        public string Login { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
    }
}