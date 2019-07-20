using MovieRental.Data.DAL.Models;
using MovieRental.Data.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Data.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Film> FilmRepository { get; }
        void Save();
    }
}
