using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataverseTest.IRepositories
{
    public interface IRepository<T> : IDisposable
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetSingleById(int Id);
        Task<T> GetSingleByFilterExpression(Expression<Func<T, bool>> filterExpression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
