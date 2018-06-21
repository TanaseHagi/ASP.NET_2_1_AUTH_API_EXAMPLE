using Microsoft.EntityFrameworkCore;

namespace ASP.NET_2_1_AUTH_API_EXAMPLE.Models
{
    public class ToDoItemContext : DbContext
    {
        public ToDoItemContext(DbContextOptions<ToDoItemContext> options) : base(options)
        {
            
        }

        public DbSet<ToDoItem> TodoItems { get; set; }
    }
}