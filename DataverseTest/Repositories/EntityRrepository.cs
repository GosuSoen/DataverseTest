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
        public virtual async Task<ICollection<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        ////Aynchronously get specific Entity by Parameter
        //public virtual async Task<T> GetManyByParameter(Expression<Func<T, bool>> filterExpression)
        //{
        //    return await _dbSet.FirstOrDefaultAsync(filterExpression);
        //}

        //Get specific record of entity T from Database by it's Id
        public virtual async Task<T> GetSingleById(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(a=>a.Id == Id);
        }

        //Aynchronously get specific Entity by Parameter
        public virtual async Task<T> GetSingleByFilterExpression(Expression<Func<T,bool>> filterExpression)
        {
            return await _dbSet.FirstOrDefaultAsync(filterExpression);
        }

        //Create new entity
        public virtual async void Create(T entity)
        {
             await _dbSet.AddAsync(entity);
             await _context.SaveChangesAsync();
        }

        //Get specific record of entity T from Database by it's Id
        public virtual async void Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        //Get specific record of entity T from Database by it's Id
        public virtual async void Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
