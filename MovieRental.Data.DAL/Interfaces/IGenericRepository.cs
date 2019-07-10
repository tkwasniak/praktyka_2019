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
        DbContext Context { get; }

        IQueryable<T> GetAll();
        IEnumerable<T> GetPaged(int pageIndex, int pageSize);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T,bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        T GetById(object id); //ID nie zawsze musi być integerem
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Delete(object id);
        void Update(T entity);
    }
}
