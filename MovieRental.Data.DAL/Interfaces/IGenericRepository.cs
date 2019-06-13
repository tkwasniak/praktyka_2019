using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Data.DAL.Repositories
{
    public interface IGenericRepository<T> where T: class 
    {
        DbContext Conext { get; }

        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Update(T entity);
    }
}
