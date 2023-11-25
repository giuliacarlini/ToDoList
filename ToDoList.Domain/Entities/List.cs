using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities
{
    public class List: Entity
    {
        public List(string title, int userId)
        {
            this.Title = title.Trim();
            this.UserId = userId;

            Validate();
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

        public void Validate()
        {
            Requires()
                .IsGreaterOrEqualsThan(Title, 10, "Title")
                .IsLowerOrEqualsThan(Title, 80, "Title")
                .IsGreaterThan(UserId, 0, "UserID");
        }
    }
}
