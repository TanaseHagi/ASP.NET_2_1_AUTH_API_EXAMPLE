using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ASP.NET_2_1_AUTH_API_EXAMPLE.Models
{
    public class ToDoUserContext : IdentityDbContext
    {
        public ToDoUserContext(DbContextOptions<ToDoUserContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoUser> TodoUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}