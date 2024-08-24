using Todos2.Models;

namespace Todos2.Services
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllTodos();
        Task<Todo> GetTodo(int id);
        Task<Todo> CreateTodo(Todo todo);
        Task <bool>UpdateTodo(Todo todo);
        Task<bool> DeleteTodo(int id);
    }
}
