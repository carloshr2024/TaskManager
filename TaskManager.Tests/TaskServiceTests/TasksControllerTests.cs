using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class TasksControllerTests : IClassFixture<WebApplicationFactory<TaskService.Startup>>
{
    private readonly HttpClient _client;

    public TasksControllerTests(WebApplicationFactory<TaskService.Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetTasks_ReturnsOk()
    {
        // Act
        var response = await _client.GetAsync("/api/tasks");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
