using Microsoft.AspNetCore.Mvc;
using UserService.Domain.Entities;
using UserService.Domain.Services;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _userService;

    public UsersController(UsersService userService)
    {
        _userService = userService; // Inyección de dependencia
    }

    // Obtiene todos los usuarios
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users); // Devuelve los usuarios en formato JSON
    }

    // Crea un nuevo usuario
    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        _userService.CreateUser(user);
        return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user); // Devuelve el usuario creado
    }
}
