using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WTPSample.Database.DAL.Contracts;

namespace WTPSample.Database.DAL.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly WtpContext _context;
        public Repository(WtpContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
          await _context.Set<T>().AddAsync(entity);
            
        }

        public void Remove(T entity)
        {
           _context.Set<T>().Remove(entity);
        
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            var data = await _context.Set<T>().ToListAsync();
            return data;
        }

    }
}
