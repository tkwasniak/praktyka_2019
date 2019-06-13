using MovieRental.Core.Logic.Mapper;
using MovieRental.Core.Logic.Models;
using MovieRental.Data.DAL.Models;
using MovieRental.Data.DAL.Repositories;

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
            }
        }
    }
}
