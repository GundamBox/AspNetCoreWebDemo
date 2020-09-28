using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class BaseEntity<TKey>
    {
        public virtual TKey Id {get;set;}
        public bool IsSoftDeleted { get; set; }
    }
}
