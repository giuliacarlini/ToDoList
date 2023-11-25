using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Flunt.Notifications;
using Flunt.Validations;

namespace ToDoList.Domain.Entities
{
    public class User: Entity
    {
        public User(string name, string email, string login, string password)
        {
            Name = name.Trim();
            Email = email.Trim();
            Login = login.Trim();
            Password = password.Trim();

            Validate();
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

            Validate();
        }

        public void Validate()
        {
            Clear();

            Requires()
                .IsGreaterOrEqualsThan(Name, 10, "Name")
                .IsLowerOrEqualsThan(Name, 100, "Name")
                .IsEmail(Email, "Email")
                .IsGreaterOrEqualsThan(Login, 10, "Login")
                .IsLowerOrEqualsThan(Login, 80, "Login")
                .IsGreaterOrEqualsThan(Password, 8, "Password")
                .IsLowerOrEqualsThan(Password, 30, "Password");
        }
    }
}