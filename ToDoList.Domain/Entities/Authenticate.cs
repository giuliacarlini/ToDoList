using ToDoList.Domain.Adapters.Handlers;

namespace ToDoList.Domain.Entities
{
    public class Authenticate: ICommand
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
