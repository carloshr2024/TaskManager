/// <summary>
/// Representa un usuario en el sistema.
/// </summary>
public class User
{
    /// <summary>
    /// Obtiene o establece el identificador único del usuario.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Obtiene o establece el nombre de usuario del usuario.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Obtiene o establece el hash de la contraseña del usuario.
    /// </summary>
    public string PasswordHash { get; set; }
}
