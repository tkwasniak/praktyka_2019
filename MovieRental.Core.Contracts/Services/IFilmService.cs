using MovieRental.Core.Contracts.Models;
using System.Collections.Generic;

namespace MovieRental.Core.Contracts.Services
{
    public interface IFilmService
    {
        void AddFilm(IFilmModel fm);
        void DeleteFilm(int id);
        void EditFilm(IFilmModel fm);
        IEnumerable<IFilmModel> GetAllFilms();
        IFilmModel GetFilm(int id);
    }
}
