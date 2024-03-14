using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Repo.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByID(int id, Expression<Func<T, object>> includeExpression = null, Expression<Func<T, bool>> filter = null);
        void Insert(T entity);
        Task<bool> Remove(Guid id);
        Task<bool> Upsert(T entity);
        Task<IEnumerable<T>> Get(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "",
        int? pageIndex = null,
        int? pageSize = null
    );

    }
}
