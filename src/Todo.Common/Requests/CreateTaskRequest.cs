﻿using System;
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
    }
}
