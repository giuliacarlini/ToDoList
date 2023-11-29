using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Commands.Request.Authentication
{
    public class AuthenticateSsoRequest: ICommand
    {
        public string Email { get; set; } = string.Empty;
        public string AppToken { get; set; } = string.Empty;
    }
}
