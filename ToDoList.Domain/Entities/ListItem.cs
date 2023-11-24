using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Commands.Request.ListItem;

namespace ToDoList.Domain.Entities
{
    public class ListItem
    {
        public ListItem(string title, string description, int idUser, int idList)
        {
            Title = title;
            Description = description;
            IdUser = idUser;
            IdList = idList;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; private set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; private set; }

        [Required]
        public int IdUser { get; private set; }

        [Required]
        public int IdList { get; private set; }

        public int IdListItem { get; private set; }

        public void Refresh(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
