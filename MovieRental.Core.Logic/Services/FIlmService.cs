using FluentValidation.Results;
using MovieRental.Core.Contracts;
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
        public FilmService(UnitOfWork unitOfWork){}

        public IFilmServiceResponse Create(IFilmModel fm)
        {
            using (var uow = new UnitOfWork())
            {
                ServiceResponse response = new ServiceResponse();
                var validator = new FilmValidator();
                var results = validator.Validate(fm);
                if (results.IsValid)
                {
                    Film film = FilmMapper.Default.Map<FilmModel, Film>(fm as FilmModel);
                    uow.FilmRepository.Add(film);
                    uow.Save();
                    response.HasSucceeded = true;
                    return response;
                }
                else
                {
                    response.HasSucceeded = false;
                    string errors = "";
                    foreach (var error in results.Errors)
                    {
                        errors +=$"{error.PropertyName}: {error.ErrorMessage} \n";
                    }
                    response.Errors = errors;
                    return response;
                }
            }
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

                Film film = FilmMapper.Default.Map<FilmModel, Film>(fm as FilmModel);
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
                FilmModel filmModel = FilmMapper.Default.Map<Film, FilmModel>(film);
                return filmModel;
            }
        }

        public IFilmServiceResponse Delete(int id)
        {
            using (var uow = new UnitOfWork())
            {
                ServiceResponse response = new ServiceResponse();
                var entry = uow.FilmRepository.GetById(id);
                if (entry == null)
                {

                    response.HasSucceeded = false;
                    response.Errors = "Record doesn't exist";
                    return response; ;
                }
                uow.FilmRepository.Delete(id);
                uow.Save();
                response.HasSucceeded = false;
                return response;
            }
        }

    }
}