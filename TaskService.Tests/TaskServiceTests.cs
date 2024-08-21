using Moq;
using System.Collections.Generic;
using System.Linq;
using TaskService.Domain.Entities;
using TaskService.Domain.Repositories;
using TaskService.Domain.Services;
using Xunit;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _taskRepositoryMock;
    private readonly TasksService _taskService;

    public TaskServiceTests()
    {
        _taskRepositoryMock = new Mock<ITaskRepository>();
        _taskService = new TasksService(_taskRepositoryMock.Object);
    }

    [Fact]
    public void GetTasks_ReturnsTasks()
    {
        // Arrange
        var tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Title = "Task 1", Description = "Description 1", IsCompleted = false },
            new TaskItem { Id = 2, Title = "Task 2", Description = "Description 2", IsCompleted = true }
        };
        //_taskRepositoryMock.Setup(repo => repo.GetAllTasks()).Returns(tasks);

        // Act
        var result = _taskService.GetTasks();

        // Assert
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void CreateTask_AddsTask()
    {
        // Arrange
        var task = new TaskItem { Title = "Task 3", Description = "Description 3", IsCompleted = false };

        // Act
        _taskService.CreateTask(task);

        // Assert
       // _taskRepositoryMock.Verify(repo => repo.AddTask(task), Times.Once);
    }
}
