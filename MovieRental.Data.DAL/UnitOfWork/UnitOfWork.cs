using MovieRental.Data.DAL.Interfaces;
using MovieRental.Data.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Data.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieRentalDbContext context;
        private GenericRepository<Film> filmRepository;

        public UnitOfWork()
        {
            this.context = new MovieRentalDbContext();
        }

        public MovieRentalDbContext DbContext
        {
            get
            {
                return this.context;
            }
        }

        public GenericRepository<Film> FilmRepository
        {
            get
            {
                if (this.filmRepository == null)
                {
                    this.filmRepository = new GenericRepository<Film>(context);
                }
                return this.filmRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private void Dispose(bool shouldDispose)
        {
            if (shouldDispose)
            {
                context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

     
    }
}
