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

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>(); // WAZNE
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
            throw new NotImplementedException();
        }
    }
}
