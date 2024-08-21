using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class UserServiceIntegrationTests : IClassFixture<WebApplicationFactory<UserService.Startup>>
{
    private readonly HttpClient _client;

    public UserServiceIntegrationTests(WebApplicationFactory<UserService.Startup> factory)
    {
        _client = factory.CreateClient(); // Crea un cliente HTTP para pruebas
    }

    [Fact]
    public async Task GetUsers_ReturnsSuccess()
    {
        // Act
        var response = await _client.GetAsync("/api/users");

        // Assert
        response.EnsureSuccessStatusCode(); // Asegura que la respuesta sea exitosa
    }
}
