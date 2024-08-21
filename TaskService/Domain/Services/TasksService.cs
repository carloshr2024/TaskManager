using System.Collections.Generic;
using TaskService.Domain.Entities;
using TaskService.Domain.Repositories;

namespace TaskService.Domain.Services
{
    // Servicio que maneja la lógica de negocio relacionada con tareas
    public class TasksService
    {
        private readonly ITaskRepository _taskRepository;

        public TasksService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository; // Inyección de dependencia
        }

        // Obtiene todas las tareas
        public IEnumerable<TaskItem> GetTasks() => _taskRepository.GetAllTasks();

        // Crea una nueva tarea
        public void CreateTask(TaskItem task) => _taskRepository.AddTask(task);
    }
}
