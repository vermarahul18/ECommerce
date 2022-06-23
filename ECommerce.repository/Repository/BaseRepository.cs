using ECommerce.Context.ECommDbContext;
using ECommerce.repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.repository.Repository
{
    public class BaseRepository<T>:IBaseRepository<T> where T:class
    {
        public DbContext Context { get; set; }

        public BaseRepository(StoreContext storeContext)
        {
            Context = storeContext;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            Context.Set<T>().UpdateRange(entity);
            return Task.FromResult(entity);
        }
        public Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entity)
        {
            Context.Set<T>().UpdateRange(entity);
            return Task.FromResult(entity);
        }

        //post
        public Task<T> AddAsync(T entity)
        {
            Context.Set<T>().AddAsync(entity);
            return Task.FromResult(entity);
        }
        public Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity)
        {
            Context.Set<T>().AddRangeAsync(entity);
            return Task.FromResult(entity);
        }

        //Savechanges
        public Task<int> SaveAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
