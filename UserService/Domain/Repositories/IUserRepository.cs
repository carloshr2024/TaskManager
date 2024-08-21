using System.Collections.Generic;
using UserService.Domain.Entities;

namespace UserService.Domain.Repositories
{
    // Interfaz para el repositorio de usuarios
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(); // Obtiene todos los usuarios
        void AddUser(User user); // Agrega un nuevo usuario
    }
}
