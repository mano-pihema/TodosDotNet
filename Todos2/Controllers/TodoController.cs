using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todos2.Data;
using Todos2.Models;
using Todos2.Services;

namespace Todos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly ITodoRepository _todoRepository;

        public TodoController(DataContext data,  ITodoRepository todoRepository)
        {
            _dataContext = data;
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetAllTodos()
        {
            //var todos = await _dataContext.Todos.ToListAsync();

            var todos = await _todoRepository.GetAllTodos();

            return Ok(todos);
        }

        [HttpGet("{id}")]
       
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            //var todo = await _dataContext.Todos.FindAsync(id);
            var todo = await _todoRepository.GetTodo(id);
            if(todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPost]

        public async Task<ActionResult<Todo>> CreateTodo(Todo todo)
        {
            //_dataContext.Add(todo);
           // await _dataContext.SaveChangesAsync();

            var createdTodo = await _todoRepository.CreateTodo(todo);


            return CreatedAtAction(nameof(GetTodo), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpPut]

        public async Task<ActionResult> UpdateTodo(Todo updateTodo)
        {
            //var todo = await _dataContext.Todos.FindAsync(updateTodo.Id);
            //if (todo == null)
            //{
            //    return NotFound();
            //}

            //todo.Title = updateTodo.Title;
            //todo.Description = updateTodo.Description;
            //await _dataContext.SaveChangesAsync();

           var todo = await _todoRepository.UpdateTodo(updateTodo);
            if (!todo)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete]

        public async Task<ActionResult> RemoveTodo(int id)
        {
           // var todo = await _dataContext.Todos.FindAsync(id);
           // if (todo == null)
           // {
           //     return NotFound();
           // }

           //_dataContext.Remove(todo);
           // await _dataContext.SaveChangesAsync();

           // return Ok();

            var todo = await _todoRepository.DeleteTodo(id);
            if (!todo)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
