using Todo.Common.Services;
using Todo.Common.Models;

namespace Todo.Test;

public class TaskServiceTest
{
    private IFileDataService service;
    public TaskServiceTest()
    {
        this.service = new DummyDataService();
    }
    [Fact]
    public void CreateTaskSucceeds()
    {
        var taskService = new TaskService(this.service);

    }
}

internal class DummyDataService : IFileDataService
{
    private readonly Dictionary<string, TaskModel> data = new Dictionary<string, TaskModel>();
    public async Task<TaskModel?> GetAsync(string id)
    {
        await Task.CompletedTask;

        return new TaskModel
        {
            Key = Guid.NewGuid().ToString()
        };
    }

    public async Task SaveAsync(TaskModel? obj)
    {
        await Task.CompletedTask;

        if (obj == null)
        {
            return;
        }
        if (data.ContainsKey(obj.Key))
        {
            data.Remove(obj.Key);
        }
        this.data.Add(obj?.Key, obj);
    }
}
