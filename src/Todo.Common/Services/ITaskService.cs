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

    public class TaskService : ITaskService
    {
        private readonly IFileDataService fileDataService;

        public TaskService(IFileDataService fileDataService)
        {
            this.fileDataService = fileDataService;
        }

        public async Task<Result> CreateTaskAsync(CreateTaskRequest request)
        {
            var modelResult = TaskModel.CreateTask(request);
            if(modelResult.IsErr())
            {
                return Result.Err(modelResult.GetErr());
            }
            await this.fileDataService.SaveAsync(modelResult.GetVal());
            return Result.Ok();
        }
    }
}
