using Entities;
using Repository.CustomSearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ITodoItemRepository
    {
        #region Create
        TodoItem Create(TodoItem obj);
        Task<TodoItem> CreateAsync(TodoItem obj);
        #endregion
        #region Read
        TodoItem Get(Expression<Func<TodoItem, bool>> predicate);
        Task<TodoItem> GetAsync(Expression<Func<TodoItem, bool>> predicate);

        IEnumerable<TodoItem> List(IBaseCustomSearch search);
        Task<IEnumerable<TodoItem>> ListAsync(IBaseCustomSearch search);
        #endregion
        #region Update
        TodoItem Update(TodoItem obj);
        Task<TodoItem> UpdateAsync(TodoItem obj);
        #endregion
        #region Delete
        void Delete(TodoItem obj);
        void Delete(Expression<Func<TodoItem, bool>> predicate);
        Task DeleteAsync(Expression<Func<TodoItem, bool>> predicate);
        Task DeleteAsync(TodoItem obj);
        #endregion
    }
}
