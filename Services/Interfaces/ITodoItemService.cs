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
        TodoItemGetViewModel Create(TodoItemCreateViewModel value);
        Task<TodoItemGetViewModel> CreateAsync(TodoItemCreateViewModel value);
        #endregion
        #region Read
        TodoItemGetViewModel Get(int id);
        Task<TodoItemGetViewModel> GetAsync(int id);
        ListOf<TodoItemGetViewModel> List(IBaseCustomSearch search);
        Task<ListOf<TodoItemGetViewModel>> ListAsync(IBaseCustomSearch search);
        #endregion
        #region Update
        TodoItemGetViewModel Update(int id, TodoItemUpdateViewModel value);
        Task<TodoItemGetViewModel> UpdateAsync(int id, TodoItemUpdateViewModel value);
        #endregion
        #region Delete
        void Delete(int id);
        Task DeleteAsync(int id);
        #endregion
    }
}
