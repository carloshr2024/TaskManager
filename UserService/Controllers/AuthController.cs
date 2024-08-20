using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controlador para la autenticación de usuarios.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    /// <summary>
    /// Inicia sesión de un usuario y devuelve un token JWT.
    /// </summary>
    /// <param name="model">Modelo que contiene las credenciales del usuario.</param>
    /// <returns>Un resultado de acción que contiene un token JWT si la autenticación es exitosa.</returns>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Implementar lógica de autenticación
        return Ok(new { Token = "JWT_TOKEN" });
    }
}
