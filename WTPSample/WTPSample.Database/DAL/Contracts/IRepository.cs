using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WTPSample.Database.DAL.Contracts
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void Remove(T entity);
    }
}
