using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Common.Requests;
using Todo.Common.Models;

namespace Todo.Common.Services
{
    public interface ITaskService
    {
        Task CreateTaskAsync(CreateTaskRequest request);

    }

    public class TaskService : ITaskService<TaskModel>
    {
        public async Task CreateTaskAsync(CreateTaskRequest request)
        {
            await Task.CompletedTask;
        }
    }
}
