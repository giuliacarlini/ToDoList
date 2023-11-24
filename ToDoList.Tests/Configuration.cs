using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Infrastructure.Context;

namespace ToDoList.Tests
{
    public class Configuration
    {
        public DataContext ConfigureContext()
        {
            var sqlLiteDataContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase("Default")
                .Options;

            return new DataContext(sqlLiteDataContextOptions);
        }
    }
}
