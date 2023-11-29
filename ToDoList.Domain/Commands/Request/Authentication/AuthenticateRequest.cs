using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Request.Authentication
{
    public class AuthenticateRequest : ICommand
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
