using System.Collections.Generic;
using System.Linq;
using ASP.NET_2_1_AUTH_API_EXAMPLE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP.NET_2_1_AUTH_API_EXAMPLE.Controllers
{
    [RequireHttps]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ToDoItemContext _context;
        private readonly ILogger _logger;

        public TodoController(ToDoItemContext context, ILogger<TodoController> logger)
        {
            _context = context;
            _logger = logger;
            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new ToDoItem { Name = "Item 1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<ToDoItem> GetById(long id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                _logger.LogError($"todo {id} was not found");
                return NotFound(new {message = $"todo {id} was not found"});
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(ToDoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, ToDoItem item)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            //return NoContent();
            return CreatedAtRoute("GetTodo", new { id = todo.Id }, todo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            // return NoContent();
            return new ObjectResult(new {deleted = true});
        }
    }
}
