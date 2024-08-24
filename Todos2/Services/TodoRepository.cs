using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Todos2.Data;
using Todos2.Models;

namespace Todos2.Services
{
    public class TodoRepository:ITodoRepository
    {
        private readonly DataContext _dataContext;
        public TodoRepository(DataContext context) {
            _dataContext = context;
        }

        public async Task<List<Todo>> GetAllTodos()
        {
            return await _dataContext.Todos.ToListAsync();
    
        }

        public async Task<Todo> GetTodo(int id)
        {

            return await _dataContext.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateTodo(Todo todo)
        {

             var res = await _dataContext.Todos.AddAsync(todo);
             await _dataContext.SaveChangesAsync();
             return res.Entity;
        }

        public async Task<bool> UpdateTodo(Todo todoUpdate)
        {
            var todo = await _dataContext.Todos.FindAsync(todoUpdate.Id);

            if (todo == null)
            {
                return false;
            }

            todo.Title = todoUpdate.Title;
            todo.Description = todoUpdate.Description;

            await _dataContext.SaveChangesAsync();

            return true;

        }

        public async Task<bool> DeleteTodo(int id)
        {
            var todo = await _dataContext.Todos.FindAsync(id);

            if (todo != null)
            {
               _dataContext.Todos.Remove(todo);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

     
    }
}
