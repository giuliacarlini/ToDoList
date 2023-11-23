using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Adapters.Handlers
{
    public interface IHandler<in T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
