using Microsoft.EntityFrameworkCore;

/// <summary>
/// Contexto de base de datos para la entidad User.
/// Hereda de <see cref="DbContext"/> para interactuar con la base de datos.
/// </summary>
public class UserContext : DbContext
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="UserContext"/>.
    /// </summary>
    /// <param name="options">Opciones de configuración para el contexto de la base de datos.</param>
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    /// <summary>
    /// Conjunto de entidades <see cref="User"/> que se pueden consultar y modificar en la base de datos.
    /// </summary>
    public DbSet<User> Users { get; set; }
}
