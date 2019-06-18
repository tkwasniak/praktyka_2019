using MovieRental.Core.Logic.Mapper;
using MovieRental.Core.Logic.Models;
using MovieRental.Data.DAL.Models;
using MovieRental.Data.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Core.Logic.Services
{
    public class FIlmService
    {
        public FIlmService()
        {
        }

        public void AddNewFilm(FilmModel fm)
        {
            using (var unitOfWOrk = new UnitOfWork())
            {
                Film film = new Film();
                film = FilmMapper.Default.Map(fm, film);
                unitOfWOrk.FilmRepository.Add(film);
                unitOfWOrk.Save();
            }
        }
        public IEnumerable<FilmModel> GetAllMovies()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                IEnumerable<Film> filmList = unitOfWork.FilmRepository.GetAll().AsEnumerable();
                IEnumerable<FilmModel> filmModelList = FilmMapper.Default.Map<IEnumerable<Film>, IEnumerable<FilmModel>>(filmList);
                return filmModelList;
            }
        }
    }
}