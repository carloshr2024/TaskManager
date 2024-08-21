using System.Collections.Generic;
using System.Linq;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;

namespace UserService.Infrastructure.Repositories
{
    // Implementación del repositorio de usuarios
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context; // Inyección de dependencia
        }

        // Obtiene todos los usuarios
        public IEnumerable<User> GetAllUsers() => _context.Users.ToList();

        // Agrega un nuevo usuario
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges(); // Guarda los cambios en la base de datos
        }
    }
}
