using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<List> List { get; set; }
        public DbSet<ListItem> ListItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();
        }
    }
}
