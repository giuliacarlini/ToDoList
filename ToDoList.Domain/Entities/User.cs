using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(80)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(80)]
        public string Login { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string Password { get; set; } = string.Empty;
    }
}