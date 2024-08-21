namespace TaskService.Domain.Entities
{
    // Representa una tarea en el sistema
    public class TaskItem
    {
        public int Id { get; set; } // Identificador único de la tarea
        public string Title { get; set; } // Título de la tarea
        public string Description { get; set; } // Descripción de la tarea
        public bool IsCompleted { get; set; } // Estado de finalización de la tarea
    }
}
