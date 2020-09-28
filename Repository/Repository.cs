using AspNetCore.IQueryable.Extensions;
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
    public class Repository<TKey, TObj> : IRepository<TObj>
        where TObj : BaseEntity<TKey>, new()
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public TObj Create(TObj obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Create data is null.");
            }
            else
            {
                _context.Set<TObj>().Add(obj);
                _context.SaveChanges();
                return obj;
            }
        }

        public async Task<TObj> CreateAsync(TObj obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Create data is null.");
            }
            else
            {
                _context.Set<TObj>().Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
        }

        public void Delete(TObj obj)
        {
            if (obj != null)
            {
                obj.IsSoftDeleted = true;
                Update(obj);
            }
        }

        public void Delete(Expression<Func<TObj, bool>> predicate)
        {
            var obj = Get(predicate);
            Delete(obj);
        }

        public async Task DeleteAsync(Expression<Func<TObj, bool>> predicate)
        {
            var obj = await GetAsync(predicate);
            await DeleteAsync(obj);
        }

        public async Task DeleteAsync(TObj obj)
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

        public TObj Get(Expression<Func<TObj, bool>> predicate)
        {
            return _context.Set<TObj>().FirstOrDefault(predicate);
        }

        public async Task<TObj> GetAsync(Expression<Func<TObj, bool>> predicate)
        {
            return await _context.Set<TObj>().FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<TObj> List(IBaseCustomSearch search)
        {
            return _context.Set<TObj>()
                .AsQueryable()
                .Apply(search)
                .ToList();
        }

        public async Task<IEnumerable<TObj>> ListAsync(IBaseCustomSearch search)
        {
            return await _context.Set<TObj>()
                                .AsQueryable()
                                .Apply(search)
                                .ToListAsync();
        }

        public TObj Update(TObj obj)
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

        public async Task<TObj> UpdateAsync(TObj obj)
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
