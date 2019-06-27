using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Contracts.Services;
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
        private UnitOfWork unitOfWork;
        public FilmService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddFilm(IFilmModel fm)
        {
            var validator = new FilmValidator();
            //var validationResult = n
            Film film = FilmMapper.Default.Map<IFilmModel, Film>(fm);
            unitOfWork.FilmRepository.Add(film);
            unitOfWork.Save();
            unitOfWork.Dispose();
        }

        public void EditFilm(IFilmModel fm)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Film film = FilmMapper.Default.Map<IFilmModel, Film>(fm);
                unitOfWork.FilmRepository.Update(film);
                unitOfWork.Save();
            }
        }
        public IEnumerable<IFilmModel> GetAllFilms()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                IEnumerable<Film> filmList = unitOfWork.FilmRepository.GetAll().AsEnumerable();
                IEnumerable<IFilmModel> filmModelList = FilmMapper.Default.Map<IEnumerable<Film>, IEnumerable<IFilmModel>>(filmList);
                return filmModelList;
            }
        }

        public IFilmModel GetFilm(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Film film = unitOfWork.FilmRepository.GetById(id);
                IFilmModel filmModel = FilmMapper.Default.Map<Film, IFilmModel>(film);
                return filmModel;
            }
        }

        public void DeleteFilm(int id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.FilmRepository.Delete(id);
                unitOfWork.Save();

            }
        }
    }
}