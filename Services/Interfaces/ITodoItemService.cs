using Entities;
using Entities.ViewModels;
using Repository.CustomSearch.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITodoItemService
    {
        #region Create
        TodoItemGetViewModel Create(TodoItem obj);
        Task<TodoItemGetViewModel> CreateAsync(TodoItem obj);
        #endregion
        #region Read
        TodoItemGetViewModel Get(Expression<Func<TodoItem, bool>> predicate);
        Task<TodoItemGetViewModel> GetAsync(Expression<Func<TodoItem, bool>> predicate);
        ListOf<TodoItemGetViewModel> List(IBaseCustomSearch search);
        Task<ListOf<TodoItemGetViewModel>> ListAsync(IBaseCustomSearch search);
        #endregion
        #region Update
        TodoItemGetViewModel Update(TodoItem obj);
        Task<TodoItemGetViewModel> UpdateAsync(TodoItem obj);
        #endregion
        #region Delete
        void Delete(TodoItem obj);
        void Delete(Expression<Func<TodoItem, bool>> predicate);
        Task DeleteAsync(Expression<Func<TodoItem, bool>> predicate);
        Task DeleteAsync(TodoItem obj);
        #endregion
    }
}
