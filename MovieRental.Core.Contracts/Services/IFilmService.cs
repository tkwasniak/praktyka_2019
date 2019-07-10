using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Core.Contracts.Services
{
    public interface IFilmService
    {
        void Create(IFilmModel fm);
        void Delete(int id);
        void Update(IFilmModel fm);
        IEnumerable<IFilmModel> GetAll(); // musi byc
        IEnumerable<IFilmModel> GetPaged(SortOrder order, int pageIndex, int pageSize);
        IFilmModel GetById(int id);
        int Count();
    }
}
