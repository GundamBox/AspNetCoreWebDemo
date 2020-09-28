using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels
{
    public class ListOf<TObj>
        where TObj : class, new()
    {
        public IEnumerable<TObj> Collection { get; set; }
        public int Total { get; set; }
    }
}
