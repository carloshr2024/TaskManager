using Microsoft.EntityFrameworkCore;
using TaskService.Domain.Entities;

namespace TaskService.Infrastructure.Data
{
    // Contexto de la base de datos para el servicio de tareas
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; } // Conjunto de tareas
    }
}
