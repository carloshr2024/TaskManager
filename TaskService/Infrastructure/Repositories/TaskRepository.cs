using System.Collections.Generic;
using System.Linq;
using TaskService.Domain.Entities;
using TaskService.Domain.Repositories;

namespace TaskService.Infrastructure.Repositories
{
    // Implementación del repositorio de tareas
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context; // Inyección de dependencia
        }

        // Obtiene todas las tareas
        public IEnumerable<TaskItem> GetAllTasks() => _context.Tasks.ToList();

        // Agrega una nueva tarea
        public void AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }
    }
}
