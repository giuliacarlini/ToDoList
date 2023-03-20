using Microsoft.EntityFrameworkCore;
using ToDoList.Features.v1.Model;

namespace ToDoList.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<List> List { get; set; }
        public DbSet<ListItem> ListItem { get; set; }
    }
}
