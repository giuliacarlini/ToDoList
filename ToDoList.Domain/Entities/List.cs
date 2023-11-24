using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities
{
    public class List
    {
        public List(string title, int userId)
        {
            this.Title = title;
            this.UserId = userId;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; private set; } 

        [Required]
        public int UserId { get; private set; }

        public void Refresh(string title)
        {
            Title = title;
        }
    }
}
