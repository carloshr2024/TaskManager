using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using UserService.Controllers;
using UserService;

public class AuthControllerTests
{
    [Fact]
    public void Login_ValidCredentials_ReturnsToken()
    {
        // Arrange
        var controller = new AuthController(/* dependencies */);
        var loginModel = new LoginModel { Username = "user", Password = "password" };

        // Act
        var result = controller.Login(loginModel) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Contains("JWT_TOKEN", result.Value.ToString());
    }

    
}
