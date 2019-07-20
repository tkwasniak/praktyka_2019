using MovieRental.Core.Contracts.Models;
using MovieRental.Web.Mapper;
using MovieRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Web.ModelsBuilder
{
    public static class FilmModelBuilder
    {
        public static FilmViewModel GetFilmViewModel(IFilmModel filmModel)
        {
            return FilmMapper.Mapping.Map<IFilmModel, FilmViewModel>(filmModel);
        }


        public static IEnumerable<FilmViewModel> GetFilmViewModelList(IEnumerable<IFilmModel> filmModelList)
        {
            return FilmMapper.Mapping.Map<IEnumerable<IFilmModel>, IEnumerable<FilmViewModel>>(filmModelList);
        }
    }
}