using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskContext _context;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="TasksController"/>.
    /// </summary>
    /// <param name="context">El contexto de la base de datos para acceder a las tareas.</param>
    public TasksController(TaskContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtiene la lista de todas las tareas.
    /// </summary>
    /// <returns>Una acción que contiene la lista de tareas.</returns>
    [HttpGet]
    public IActionResult GetTasks()
    {
        var tasks = _context.Tasks.ToList();
        return Ok(tasks);
    }
}
