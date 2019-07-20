using MovieRental.Core.Contracts.Enums;
using MovieRental.Core.Contracts.Models;
using MovieRental.Core.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieRental.Core.Contracts.Interfaces
{
    public interface IFilmService
    {
        ServiceResponse Create(FilmModel fm);
        ServiceResponse Delete(int id);
        ServiceDataResponse<IEnumerable<FilmModel>> GetAll(); 
        ServiceDataResponse<IEnumerable<FilmModel>> GetPaged(SortOrder order, int pageIndex, int pageSize);
        ServiceDataResponse<FilmModel> GetById(int id);
        int Count();
        ServiceResponse Update(FilmModel fm);
    }
}
