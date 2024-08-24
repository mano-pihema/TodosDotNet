using Microsoft.EntityFrameworkCore;
using Todos2.Models;

namespace Todos2.Data
{
    public class DataContext:DbContext 
    {
        public DataContext(DbContextOptions<DataContext>options):base(options) { }

        public DbSet<Todo> Todos { get; set; }
       
    }
}
