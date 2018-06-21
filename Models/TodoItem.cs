namespace ASP.NET_2_1_AUTH_API_EXAMPLE.Models
{
    public class ToDoItem
    {
        public ToDoUser ToDoUserId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
