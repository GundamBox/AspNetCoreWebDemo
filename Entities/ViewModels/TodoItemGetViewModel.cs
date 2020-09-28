using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels
{
    public class TodoItemGetViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
