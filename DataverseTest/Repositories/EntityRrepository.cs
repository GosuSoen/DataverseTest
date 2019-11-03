using DataverseTest.IRepositories;
using DataverseTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataverseTest.Repositories
{
    public class EntityRrepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly DataverseDbContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityRrepository(DataverseDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        //Get Records of entity T from Database
        public ICollection<T> GetAll()
        {
            return _dbSet.ToList();
        }

        //Get specific record of entity T from Database by it's Id
        public T GetSingleById(int Id)
        {
            return _dbSet.FirstOrDefault(a=>a.Id == Id);
        }

        //Aynchronously get specific Entity by Parameter
        public T GetSingleByFilterExpression(Expression<Func<T,bool>> filterExpression)
        {
            return _dbSet.FirstOrDefault(filterExpression);
        }

        //Create new entity
        public void Create(T entity)
        {
              _dbSet.Add(entity);
        }

        //Get specific record of entity T from Database by it's Id
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        //Get specific record of entity T from Database by it's Id
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
