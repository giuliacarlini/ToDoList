using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.Data
{
    public class DataContext : DbContext
    {        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
