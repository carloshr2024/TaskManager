using Microsoft.EntityFrameworkCore;
using TaskService.Domain.Entities;

public class TaskContext : DbContext
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="TaskContext"/> con las opciones especificadas.
    /// </summary>
    /// <param name="options">Las opciones de contexto de base de datos.</param>
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

    /// <summary>
    /// Obtiene o establece la colección de tareas en la base de datos.
    /// </summary>
    public DbSet<TaskItem> Tasks { get; set; }
}
