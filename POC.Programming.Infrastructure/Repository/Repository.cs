using Microsoft.EntityFrameworkCore;
using POC.Programming.Domain;
using POC.Programming.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POC.Programming.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly ProgrammingContext context;
        private readonly DbSet<T> entities;
        protected IQueryable<T> All => entities.AsNoTracking();
        public Repository(ProgrammingContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return All.AsEnumerable();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(All.AsEnumerable());
        }

        public Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(All.Where(predicate));
        }

        public Task<IQueryable<T>> GetAllIncludingAsync(params Expression<Func<T, object>>[] propertySelectors)
        {
            var query = All;

            if (propertySelectors != null && propertySelectors.Length > 0)
            {
                foreach (var propertySelector in propertySelectors)
                {
                    query = query.Include(propertySelector);
                }
            }

            return Task.FromResult(query);
        }

        public T Get(int id)
        {
            return All.SingleOrDefault(s => s.Id == id);
        }

        public Task<T> GetAsync(int id)
        {
            return All.SingleOrDefaultAsync(s => s.Id == id);
        }

        public void Add(T entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Task<int> Count()
        {
            return All.CountAsync();
        }
    }
}
