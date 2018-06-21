using Microsoft.AspNetCore.Identity;

namespace ASP.NET_2_1_AUTH_API_EXAMPLE.Models
{
    public class ToDoUser : IdentityUser
    {
        public string Location { get; set; }
    }
}