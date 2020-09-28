using AutoMapper;
using Entities;
using Entities.ViewModels;
using Repository.CustomSearch.Interfaces;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services
{
    public class TodoItemService : ITodoItemService
    {
        private IMapper _mapper;
        private readonly IRepository<TodoItem> _repository;

        public TodoItemService(IMapper mapper, IRepository<TodoItem> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public TodoItemGetViewModel Create(TodoItem obj)
        {
            var item = _repository.Create(obj);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(item);
            return viewmodel;
        }

        public async Task<TodoItemGetViewModel> CreateAsync(TodoItem obj)
        {
            var item = await _repository.CreateAsync(obj);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(item);
            return viewmodel;
        }

        public void Delete(TodoItem obj)
        {
            _repository.Delete(obj);
        }

        public void Delete(Expression<Func<TodoItem, bool>> predicate)
        {
            _repository.Delete(predicate);
        }

        public async Task DeleteAsync(Expression<Func<TodoItem, bool>> predicate)
        {
            await _repository.DeleteAsync(predicate);
        }

        public async Task DeleteAsync(TodoItem obj)
        {
            await _repository.DeleteAsync(obj);
        }

        public TodoItemGetViewModel Get(Expression<Func<TodoItem, bool>> Get)
        {
            var item = _repository.Get(Get);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(item);
            return viewmodel;
        }

        public async Task<TodoItemGetViewModel> GetAsync(Expression<Func<TodoItem, bool>> predicate)
        {
            var item = await _repository.GetAsync(predicate);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(item);
            return viewmodel;
        }

        public ListOf<TodoItemGetViewModel> List(IBaseCustomSearch search)
        {
            var items = _repository.List(search);
            var viewmodel = new ListOf<TodoItemGetViewModel>
            {
                Collection = _mapper.Map<IEnumerable<TodoItemGetViewModel>>(items),
                Total = items.Count()
            };
            return viewmodel;
        }

        public async Task<ListOf<TodoItemGetViewModel>> ListAsync(IBaseCustomSearch search)
        {
            var items = await _repository.ListAsync(search);
            var viewmodel = new ListOf<TodoItemGetViewModel>
            {
                Collection = _mapper.Map<IEnumerable<TodoItemGetViewModel>>(items),
                Total = items.Count()
            };
            return viewmodel;
        }

        public TodoItemGetViewModel Update(TodoItem obj)
        {
            var item = _repository.Update(obj);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(item);
            return viewmodel;
        }

        public async Task<TodoItemGetViewModel> UpdateAsync(TodoItem obj)
        {
            var item = await _repository.UpdateAsync(obj);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(item);
            return viewmodel;
        }
    }
}
