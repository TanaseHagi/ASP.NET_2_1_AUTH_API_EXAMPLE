using Microsoft.EntityFrameworkCore;

namespace ASP.NET_2_1_AUTH_API_EXAMPLE.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}