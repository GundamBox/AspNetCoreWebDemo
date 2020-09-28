using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using Repository.CustomSearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.CustomSearch
{
    public class TodoItemCustomSearch : IBaseCustomSearch
    {
        [QueryOperator(Operator = WhereOperator.Contains, HasName = "Content")]
        public string Query { get; set; }
        public string Sort { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}
