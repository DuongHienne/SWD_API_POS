using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SWD_Order.Repo.Entity;
using SWD_Order.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Repo.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected WPF_MachineContext _context;
        protected DbSet<T> dbSet;
        
        public GenericRepository(WPF_MachineContext context)
        {
            _context = context;
            dbSet = context.Set<T>();

        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            int? pageIndex = null,
            int? pageSize = null)
        {

            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            int totalItems = query.Count();
            // Implementing pagination
            if (pageIndex.HasValue && pageSize.HasValue)
            {
                // Ensure the pageIndex and pageSize are valid
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10; // Assuming a default pageSize of 10 if an invalid value is passed

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            return query.ToList();
        }

        public virtual async Task<T> GetByID(int id, Expression<Func<T, object>> includeExpression = null, Expression<Func<T, bool>> filter = null)
        {
            try
            {
                var query = dbSet.AsQueryable();

                if (includeExpression != null)
                {
                    query = query.Include(includeExpression);
                }
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                return await query.FirstOrDefaultAsync(x => EF.Property<int>(x, "ProductId") == (int)id);
                // Adjust the property type ("int") based on your actual entity key type
            }
            catch (Exception ex)
            {
                // In ra thông điệp lỗi chi tiết
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                throw; // Ném lại ngoại lệ để xử lý ở nơi gọi
            }
        }


        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
