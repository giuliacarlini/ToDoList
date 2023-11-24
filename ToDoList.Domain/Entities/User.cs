using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities
{
    public class User
    {
        public User(string name, string email, string login, string password)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; private set; } 

        [Required]
        [MaxLength(80)]
        public string Login { get; private set; } 

        [Required]
        [MaxLength(30)]
        public string Password { get; private set; }

        public void Refresh(string name, string email, string login, string password)
        {
            Name = name.Length > 0 ? name : Name;
            Email = email.Length > 0 ? email : Email;
            Login = login.Length > 0 ? login : Login;
            Password = password.Length > 0 ? password : Password;
        }
    }
}