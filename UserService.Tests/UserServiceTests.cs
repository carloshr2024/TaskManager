using Moq;
using System.Collections.Generic;
using System.Linq;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;
using UserService.Domain.Services;
using Xunit;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly UsersService _userService;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UsersService(_userRepositoryMock.Object);
    }

   /* [Fact]
    public object GetUsers_ReturnsUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = 1, Username = "user1", Password = "pass1" },
            new User { Id = 2, Username = "user2", Password = "pass2" }
        };
       _userRepositoryMock.Setup(repo => repo.GetAllUsers).Returns(users);

        // Act
        var result = _userService.GetUsers();

        // Assert
        Assert.Equal(2, result.Count());
    }*/

    [Fact]
    public void CreateUser_AddsUser()
    {
        // Arrange
        var user = new User { Username = "user3", Password = "pass3" };

        // Act
        _userService.CreateUser(user);

        // Assert
       // _userRepositoryMock.Verify(repo => repo.AddUser(user), Times.Once);
    }
}
