using Repository.CustomSearch;
using Repository.CustomSearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<TObj> : IDisposable
        where TObj : class, new()
    {
        #region Create
        TObj Create(TObj obj);
        Task<TObj> CreateAsync(TObj obj);
        #endregion
        #region Read
        TObj Get(Expression<Func<TObj, bool>> predicate);
        Task<TObj> GetAsync(Expression<Func<TObj, bool>> predicate);

        IEnumerable<TObj> List(IBaseCustomSearch search);
        Task<IEnumerable<TObj>> ListAsync(IBaseCustomSearch search);
        #endregion
        #region Update
        TObj Update(TObj obj);
        Task<TObj> UpdateAsync(TObj obj);
        #endregion
        #region Delete
        void Delete(TObj obj);
        void Delete(Expression<Func<TObj, bool>> predicate);
        Task DeleteAsync(Expression<Func<TObj, bool>> predicate);
        Task DeleteAsync(TObj obj);
        #endregion
    }
}
