using System.Collections.Generic;
using TaskService.Domain.Entities;

namespace TaskService.Domain.Repositories
{
    // Interfaz para el repositorio de tareas
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAllTasks(); // Obtiene todas las tareas
        void AddTask(TaskItem task); // Agrega una nueva tarea
    }
}
