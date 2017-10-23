using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdApp.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}