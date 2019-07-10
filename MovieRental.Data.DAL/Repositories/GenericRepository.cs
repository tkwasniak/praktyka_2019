using MovieRental.Data.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Data.DAL.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>(); // WAZNE
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            T entity = dbSet.Find(id);
            Delete(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity); 
            context.Entry(entity).State = EntityState.Modified;
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Single(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return dbSet.SingleOrDefault(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return dbSet.First(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetPaged(int page, int pageSize)
        {
            return dbSet.OrderBy(x => x).Skip( (page - 1) * pageSize).Take(pageSize);
        }

        public int Count()
        {
            return dbSet.Count();
        }
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Count(predicate);
        }
    }
}
