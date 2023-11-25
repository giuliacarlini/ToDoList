using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using ToDoList.Domain.Commands.Request.ListItem;

namespace ToDoList.Domain.Entities
{
    public class ListItem: Entity
    {
        public ListItem(string title, string description, int idUser, int idList)
        {
            Title = title.Trim();
            Description = description.Trim();
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
            Title = title ?? Title;
            Description = description ?? Description;
        }

        public void Validate()
        {
            Clear();

            Requires()
                .IsGreaterOrEqualsThan(Title, 10, "Title")
                .IsLowerOrEqualsThan(Title, 80, "Title")
                .IsGreaterOrEqualsThan(Description, 10, "Title")
                .IsLowerOrEqualsThan(Description, 80, "Title")
                .IsGreaterThan(IdUser, 0, "IdUser")
                .IsGreaterThan(IdList, 0, "IdList");
        }
    }
}
