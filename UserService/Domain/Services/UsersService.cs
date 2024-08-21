using System.Collections.Generic;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;

namespace UserService.Domain.Services
{
    // Servicio que maneja la lógica de negocio relacionada con usuarios
    public class UsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository; // Inyección de dependencia
        }

        // Obtiene todos los usuarios
        public IEnumerable<User> GetUsers() => _userRepository.GetAllUsers();

        // Crea un nuevo usuario
        public void CreateUser(User user) => _userRepository.AddUser(user);
    }
}
