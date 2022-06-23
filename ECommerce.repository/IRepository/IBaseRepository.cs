using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.repository.IRepository
{
    public interface IBaseRepository<T>
    {
        public DbContext Context { get; set; }

        //Get
        Task<T> GetAsync(Expression<Func<T,bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();

        //put
        /*Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entity);

        //post
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity);

        //Savechanges
        Task<int> SaveAsync();

        //delete*/

    }
}
