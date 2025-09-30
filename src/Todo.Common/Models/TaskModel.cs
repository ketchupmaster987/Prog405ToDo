using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Common.Models
{
    public class TaskModel
    {
        public TaskModel()
        {
            Key = string.Empty;
        }

        public string Key { get; set; }
    }
}
