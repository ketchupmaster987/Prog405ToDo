using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Common.Requests
{
    public class CreateTaskRequest
    {
        public CreateTaskRequest(string name, string desc, DateTime dueDate)
        {
            Name = name;
            Description = desc;
            DueDate = dueDate;
        }

        public string Name { get; }
        public string Description { get; }
        public DateTime DueDate { get; }

        public Result IsValid()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                return Result.Err("Name Required");
            }
            if (this.DueDate <= DateTime.UtcNow)
            {
                return Result.Err("Due date must be in future");
            }
            return Result.Ok();
        }
    }
}
