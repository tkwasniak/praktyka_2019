using FluentValidation.Results;
using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Contracts.Services;
using MovieRental.Core.Logic.Common;
using MovieRental.Core.Logic.Mapper;
using MovieRental.Core.Logic.Models;
using MovieRental.Core.Logic.Validators;
using MovieRental.Data.DAL.Models;
using MovieRental.Data.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Core.Logic.Services
{
    public class FilmService : IFilmService
    {
        private UnitOfWork unitOfWork;
        public FilmService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(IFilmModel fm)
        {
            using (var uow = new UnitOfWork())
            {
                List<string> errors = new List<string>();
                var validator = new FilmValidator();
                var results = validator.Validate(fm);
                foreach(ValidationFailure error in results.Errors)
                {
                    //errors.Add()
                }
                Film film = FilmMapper.Default.Map<IFilmModel, Film>(fm);
                uow.FilmRepository.Add(film);
                uow.Save();
            }
            //check whether the film already exists

        }

        public int Count()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.FilmRepository.Count();
            }
        }

        public void Update(IFilmModel fm)
        {
            using (var uow = new UnitOfWork())
            {
                Film film = FilmMapper.Default.Map<IFilmModel, Film>(fm);
                uow.FilmRepository.Update(film);
                uow.Save();
            }
        }

        public IEnumerable<IFilmModel> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                IQueryable<Film> dbFilms = uow.FilmRepository.GetAll();
                IEnumerable<FilmModel> films = FilmMapper.Default.Map<IQueryable<Film>, IEnumerable<FilmModel>>(dbFilms);
                return films;
            }
        }

        public IEnumerable<IFilmModel> GetPaged(SortOrder sortOrder, int page, int pageSize)
        {
            using (var uow = new UnitOfWork())
            {
                IQueryable<Film> dbFilms = uow.FilmRepository.GetAll();
                switch (sortOrder)
                {
                    case SortOrder.Title:
                        {
                            dbFilms = dbFilms.OrderBy(f => f.Title); ;
                            break;
                        };
                    case SortOrder.Release:
                        {
                            dbFilms = dbFilms.OrderBy(f => f.Release); ;
                            break;
                        };
                    case SortOrder.Director:
                        {
                            dbFilms = dbFilms.OrderBy(f => f.Director);
                            break;
                        };
                    default:
                        {
                            dbFilms = dbFilms.OrderBy(f => f.Id);
                            break;
                        };
                }
                var pagedFilms = dbFilms.GetPaged(page, pageSize);


                IEnumerable<FilmModel> filmsModel = FilmMapper.Default.Map<IEnumerable<Film>, IEnumerable<FilmModel>>(pagedFilms);
                return filmsModel;
            }
        }


        public IFilmModel GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                Film film = uow.FilmRepository.GetById(id);
                IFilmModel filmModel = FilmMapper.Default.Map<Film, IFilmModel>(film);
                return filmModel;
            }
        }

        public void Delete(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var entry = uow.FilmRepository.GetById(id);
                if (entry == null)
                {
                    //return message
                    return;
                }
                uow.FilmRepository.Delete(id);
                uow.Save();

            }
        }

    }
}