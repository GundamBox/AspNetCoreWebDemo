using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;

namespace Repository.CustomSearch.Interfaces
{
    public interface IBaseCustomSearch : ICustomQueryable, IQuerySort, IQueryPaging
    {
    }
}
