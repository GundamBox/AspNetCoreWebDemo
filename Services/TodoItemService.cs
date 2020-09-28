using AutoMapper;
using Entities;
using Entities.ViewModels;
using Repository.CustomSearch.Interfaces;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IMapper _mapper;
        private readonly ITodoItemRepository _repository;

        public TodoItemService(IMapper mapper, ITodoItemRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public TodoItemGetViewModel Create(TodoItemCreateViewModel value)
        {
            TodoItem item = new TodoItem
            {
                Content = value.Content,
                CreatedAt = DateTime.Now
            };
            var model = _repository.Create(item);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(model);
            return viewmodel;
        }

        public async Task<TodoItemGetViewModel> CreateAsync(TodoItemCreateViewModel value)
        {
            TodoItem item = new TodoItem
            {
                Content = value.Content,
                CreatedAt = DateTime.Now
            };
            var model = await _repository.CreateAsync(item);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(model);
            return viewmodel;
        }

        public void Delete(int id)
        {
            _repository.Delete(x => x.Id.Equals(id));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(x => x.Id.Equals(id));
        }

        public TodoItemGetViewModel Get(int id)
        {
            var item = _repository.Get(x => x.Id.Equals(id));
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(item);
            return viewmodel;
        }

        public async Task<TodoItemGetViewModel> GetAsync(int id)
        {
            var item = await _repository.GetAsync(x => x.Id.Equals(id));
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

        public TodoItemGetViewModel Update(int id, TodoItemUpdateViewModel value)
        {
            var model = _repository.Get(x => x.Id.Equals(id));
            if (value.Content != null)
            {
                model.Content = value.Content;
            }
            if (value.IsCompleted != null)
            {
                model.IsCompleted = value.IsCompleted.Value;
            }
            var item = _repository.Update(model);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(item);
            return viewmodel;
        }

        public async Task<TodoItemGetViewModel> UpdateAsync(int id, TodoItemUpdateViewModel value)
        {
            var model = await _repository.GetAsync(x => x.Id.Equals(id));
            if (value.Content != null)
            {
                model.Content = value.Content;
            }
            if (value.IsCompleted != null)
            {
                model.IsCompleted = value.IsCompleted.Value;
            }
            var item = _repository.UpdateAsync(model);
            var viewmodel = _mapper.Map<TodoItemGetViewModel>(item);
            return viewmodel;
        }
    }
}
