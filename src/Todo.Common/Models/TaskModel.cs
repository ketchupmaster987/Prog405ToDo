using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Common.Requests;

namespace Todo.Common.Models
{
    public class TaskModel
    {
        public TaskModel()
        {
            Key = string.Empty;
            //name must exist
            Name = string.Empty;
            //optional
            Description = string.Empty;
            //must be in the future and exist
            DueDate = DateTime.MinValue.ToUniversalTime();
        }

        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public static Result<TaskModel> CreateTask(CreateTaskRequest request)
        {
            var validationResult = request.IsValid();
            if(validationResult.IsErr())
            {
                return Result<TaskModel>.Err(validationResult.GetErr());
            }
            return Result<TaskModel>.Ok(new TaskModel
            {
                Key = Guid.NewGuid().ToString(),
                Name = request.Name,
                Description = request.Description,
                DueDate = request.DueDate
            });
        }
    }
}
