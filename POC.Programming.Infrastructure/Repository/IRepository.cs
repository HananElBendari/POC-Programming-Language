using POC.Programming.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POC.Programming.Infrastructure.Repository
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] propertySelectors);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        T Get(int id);
        Task<T> GetAsync(int id);
        void Add(T entity);
        void Update(T entity);
        Task<int> Count();
    }
}
