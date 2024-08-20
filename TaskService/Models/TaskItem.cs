public class TaskItem
{
    /// <summary>
    /// Obtiene o establece el identificador único de la tarea.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene o establece la descripción de la tarea.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Obtiene o establece un valor que indica si la tarea está completada.
    /// </summary>
    public bool IsCompleted { get; set; }
}
