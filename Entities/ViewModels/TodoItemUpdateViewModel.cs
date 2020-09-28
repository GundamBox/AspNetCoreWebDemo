using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.ViewModels
{
    public class TodoItemUpdateViewModel
    {
        [MaxLength(1024)]
        public string Content { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
