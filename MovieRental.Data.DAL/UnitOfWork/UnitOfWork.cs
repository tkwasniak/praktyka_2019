using MovieRental.Data.DAL.Interfaces;
using MovieRental.Data.DAL.Models;
using System;

namespace MovieRental.Data.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieRentalEntities context;
        private GenericRepository<Film> filmRepository;

        public UnitOfWork()
        {
            this.context = new MovieRentalEntities();
        }

        public MovieRentalEntities DbContext
        {
            get
            {
                return this.context;
            }
        }

        public IGenericRepository<Film> FilmRepository
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


        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
