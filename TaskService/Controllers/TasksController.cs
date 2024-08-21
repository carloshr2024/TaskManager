using Microsoft.AspNetCore.Mvc;
using TaskService.Domain.Entities;
using TaskService.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TasksService _taskService;

    public TasksController(TasksService taskService)
    {
        _taskService = taskService; // Inyección de dependencia
    }

    // Obtiene todas las tareas
    [HttpGet]
    public IActionResult GetTasks()
    {
        var tasks = _taskService.GetTasks();
        return Ok(tasks); // Devuelve las tareas en formato JSON
    }

    // Crea una nueva tarea
    [HttpPost]
    public IActionResult CreateTask(TaskItem task)
    {
        _taskService.CreateTask(task);
        return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task); // Devuelve la tarea creada
    }
}
