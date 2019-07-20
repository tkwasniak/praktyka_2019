using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Interfaces;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Logic.Common;
using MovieRental.Core.Logic.Mapper;
using MovieRental.Core.Logic.Validators;
using MovieRental.Data.DAL.Models;
using MovieRental.Data.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Core.Logic.Services
{
    public class FilmService : IFilmService
    {

        public FilmService(/*,ILoggerFactory loggerFactory*/)
        {
            //logger = loggerFactory.GetLogger("FilmServiceLog");
        }

        public ServiceResponse Create(FilmModel fm)
        {
            using (var uow = new UnitOfWork())
            {
                if (fm != null && fm.Id != 0)
                {
                    return new ServiceResponse
                    {
                        HasSucceeded = false,
                        Errors = new List<string> { "Id should not be set" }
                    };
                }
                var validator = new FilmValidator();
                var results = validator.Validate(fm);
                if (results.IsValid)
                {
                    uow.FilmRepository.Add(FilmMapper.Mapping.Map<IFilmModel, Film>(fm));
                    uow.Save();
                    return new ServiceResponse { HasSucceeded = true };
                }
                else
                {
                    List<string> errors = new List<string>();
                    foreach (var error in results.Errors)
                    {
                        errors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                    }
                    return new ServiceResponse
                    {
                        HasSucceeded = false,
                        Errors = errors
                    };
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

        public ServiceResponse Update(FilmModel fm)
        {
            using (var uow = new UnitOfWork())
            {
                var validator = new FilmValidator();
                var results = validator.Validate(fm);
                if (results.IsValid)
                {
                    uow.FilmRepository.Update(FilmMapper.Mapping.Map<FilmModel, Film>(fm as FilmModel));
                    uow.Save();
                    return new ServiceResponse { HasSucceeded = true };
                }
                else
                {
                    List<string> errors = new List<string>();
                    foreach (var error in results.Errors)
                    {
                        errors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                    }
                    return new ServiceResponse { HasSucceeded = false, Errors = errors };
                }
            }
        }

        public ServiceDataResponse<IEnumerable<FilmModel>> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                var repoData = uow.FilmRepository.GetAll();
                return new ServiceDataResponse<IEnumerable<FilmModel>>
                {
                    HasSucceeded = true,
                    Data = FilmMapper.Mapping.Map<IQueryable<Film>, IEnumerable<FilmModel>>(repoData)
                };
            }
        }

        public ServiceDataResponse<IEnumerable<FilmModel>> GetPaged(SortOrder sortBy, int page, int pageSize)
        {
            using (var uow = new UnitOfWork())
            {
                var repoData = uow.FilmRepository.GetAll();
                switch (sortBy)
                {
                    case SortOrder.Title:
                        {
                            repoData = repoData.OrderBy(f => f.Title);
                            break;
                        };
                    case SortOrder.Release:
                        {
                            repoData = repoData.OrderBy(f => f.Release); ;
                            break;
                        };
                    case SortOrder.Director:
                        {
                            repoData = repoData.OrderBy(f => f.Director);
                            break;
                        };
                    default:
                        {
                            repoData = repoData.OrderBy(f => f.Id);
                            break;
                        };
                }
                var pagedFilms = repoData.GetPaged(page, pageSize);
                if (pagedFilms == null)
                {
                    return new ServiceDataResponse<IEnumerable<FilmModel>>
                    {
                        HasSucceeded = false,
                        Errors = new List<string> { "Records could not be found" }
                    };
                }
                return new ServiceDataResponse<IEnumerable<FilmModel>>
                {
                    HasSucceeded = true,
                    Data = FilmMapper.Mapping.Map<IEnumerable<Film>, IEnumerable<FilmModel>>(pagedFilms)
                };
            }

        }

        public ServiceDataResponse<FilmModel> GetById(int id)
        {
            using (var uow = new UnitOfWork())
            {
                Film repoData = uow.FilmRepository.GetById(id);
                if (repoData == null)
                {
                    return new ServiceDataResponse<FilmModel>
                    {
                        HasSucceeded = false,
                        Errors = new List<string> { "Record could not be found" }
                    };
                }
                else
                {
                    return new ServiceDataResponse<FilmModel>
                    {
                        HasSucceeded = true,
                        Data = FilmMapper.Mapping.Map<Film, FilmModel>(repoData)
                    };
                }
            }

        }

        public ServiceResponse Delete(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var entry = uow.FilmRepository.GetById(id);
                if (entry == null)
                {
                    return new ServiceResponse
                    {
                        HasSucceeded = false,
                        Errors = new List<string> { "record doesn't exist" },
                    };
                }
                uow.FilmRepository.Delete(id);
                uow.Save();
                return new ServiceResponse { HasSucceeded = true };
            }
        }
    }
}