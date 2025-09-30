using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Common.Models;

namespace Todo.Common.Extensions
{
    public static class TaskModelExtensions
    {
        public static string ToFileName(this TaskModel model)
        {
            return $"{model.Key}.json";
        }

        public static string ToFileName(string key)
        {
            return $"{key}.json";
        }
    }
}
