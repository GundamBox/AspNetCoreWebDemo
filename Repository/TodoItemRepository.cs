using AspNetCore.IQueryable.Extensions;
using Database.Context;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.CustomSearch.Interfaces;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        protected readonly WebDemoDbContext _context;

        public TodoItemRepository(WebDemoDbContext context)
        {
            _context = context;
        }

        public TodoItem Create(TodoItem obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Create data is null.");
            }
            else
            {
                _context.Set<TodoItem>().Add(obj);
                _context.SaveChanges();
                return obj;
            }
        }

        public async Task<TodoItem> CreateAsync(TodoItem obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Create data is null.");
            }
            else
            {
                _context.Set<TodoItem>().Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
        }

        public void Delete(TodoItem obj)
        {
            if (obj != null)
            {
                obj.IsSoftDeleted = true;
                Update(obj);
            }
        }

        public void Delete(Expression<Func<TodoItem, bool>> predicate)
        {
            var obj = Get(predicate);
            Delete(obj);
        }

        public async Task DeleteAsync(Expression<Func<TodoItem, bool>> predicate)
        {
            var obj = await GetAsync(predicate);
            await DeleteAsync(obj);
        }

        public async Task DeleteAsync(TodoItem obj)
        {
            if (obj != null)
            {
                _context.Entry(obj).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public TodoItem Get(Expression<Func<TodoItem, bool>> predicate)
        {
            return _context.Set<TodoItem>().FirstOrDefault(predicate);
        }

        public async Task<TodoItem> GetAsync(Expression<Func<TodoItem, bool>> predicate)
        {
            return await _context.Set<TodoItem>().FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<TodoItem> List(IBaseCustomSearch search)
        {
            return _context.Set<TodoItem>()
                .AsQueryable()
                .Apply(search)
                .ToList();
        }

        public async Task<IEnumerable<TodoItem>> ListAsync(IBaseCustomSearch search)
        {
            return await _context.Set<TodoItem>()
                                .AsQueryable()
                                .Apply(search)
                                .ToListAsync();
        }

        public TodoItem Update(TodoItem obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Update data is null.");
            }
            else
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
                return obj;
            }
        }

        public async Task<TodoItem> UpdateAsync(TodoItem obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Update data is null.");
            }
            else
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return obj;
            }
        }
    }
}
