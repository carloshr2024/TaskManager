using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class TaskServiceIntegrationTests : IClassFixture<WebApplicationFactory<TaskService.Startup>>
{
    private readonly HttpClient _client;

    public TaskServiceIntegrationTests(WebApplicationFactory<TaskService.Startup> factory)
    {
        _client = factory.CreateClient(); // Crea un cliente HTTP para pruebas
    }

    [Fact]
    public async Task GetTasks_ReturnsSuccess()
    {
        // Act
        var response = await _client.GetAsync("/api/tasks");

        // Assert
        response.EnsureSuccessStatusCode(); // Asegura que la respuesta sea exitosa
    }
}
