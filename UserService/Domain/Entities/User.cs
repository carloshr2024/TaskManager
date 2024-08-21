namespace UserService.Domain.Entities
{
    // Representa un usuario en el sistema
    public class User
    {
        public int Id { get; set; } // Identificador único del usuario
        public string Username { get; set; } // Nombre de usuario
        public string Password { get; set; } // Contraseña del usuario
    }
}
